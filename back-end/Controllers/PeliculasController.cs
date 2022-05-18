using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Repositorio;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace back_end.Controllers
{
    [Route("api/Peliculas")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class PeliculasController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<PeliculasController> Logger;
        private readonly ApplicationDbContext _context;

        private readonly string contenedor = "Peliculas";

        public PeliculasController(
             ILogger<PeliculasController> logger
            , ApplicationDbContext context
            , IMapper mapper
            , IAlmacenadorArchivos almacenadorArchivos
            , UserManager<IdentityUser> userManager
            )
        {

            Logger = logger;
            _context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
            this.userManager = userManager;
        }


        //[HttpGet]//   api/Peliculas

        //public async Task<ActionResult<List<PeliculasDTO>>> GetAsync([FromQuery] PaginacionDTO paginacionDTO)
        //{

        //    var queryable = _context.Peliculas.AsQueryable();
        //    await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
        //    var Peliculas = queryable.OrderBy(x => x.Titulo).Paginar(paginacionDTO);

        //    return Ok(mapper.Map<List<PeliculasDTO>>(Peliculas));
        //}


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<LangingPageDTO>> get()
        {
            var top = 6;
            var hoy = DateTime.Today;
            var proximosEstrenos = await _context.Peliculas
                .Where(x => x.FechaLanzamiento > hoy)
                .OrderBy(x => x.FechaLanzamiento)
                .Take(top)
                .ToListAsync();

            var enCines = await _context.Peliculas
                .Where(x => x.EnCines)
                .OrderBy(x => x.FechaLanzamiento)
                .Take(top)
                .ToListAsync();

            var resultado = new LangingPageDTO();
            resultado.ProximosEstrenos = mapper.Map<List<PeliculasDTO>>(proximosEstrenos);
            resultado.EnCines = mapper.Map<List<PeliculasDTO>>(enCines);

            return resultado;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<PeliculasDTO>> Get(int id)
        {
            var pelicula = await _context.Peliculas
                //asu vez traer el genero
                .Include(x => x.PeliculasGeneros).ThenInclude(x => x.Generos)
                .Include(x => x.PeliculasActores).ThenInclude(x => x.Actores)
                .Include(x => x.PeliculasCines).ThenInclude(x => x.Cines)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null) { return NotFound(); }

            var promedioVoto = 0.0;
            var usuarioVoto = 0;

            if (await _context.Ratings.AnyAsync(x => x.PeliculaId == id))
            {

                promedioVoto = await _context.Ratings.Where(x => x.PeliculaId == id)
                    .AverageAsync(x => x.Puntuacion);

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                    var usuario = await userManager.FindByEmailAsync(email);
                    var usuarioId = usuario.Id;

                    var ratinDB = await _context.Ratings
                      .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.PeliculaId == id);

                    if (ratinDB != null)
                    {
                        usuarioVoto = ratinDB.Puntuacion;
                    }

                }              

            }

            var dto = mapper.Map<PeliculasDTO>(pelicula);
            dto.VotoUsuario = usuarioVoto;
            dto.PromedioVoto = promedioVoto;
            dto.Actores = dto.Actores.OrderBy(x => x.Orden).ToList();
            return dto;
        }

        [HttpGet("filtrar")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PeliculasDTO>>> Filtrar([FromQuery] PeliculasFiltrarDTO peliculasFiltrarDTO)
        {
            var peliculasQueryable = _context.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(peliculasFiltrarDTO.Titulo))
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.Titulo.Contains(peliculasFiltrarDTO.Titulo));
            }

            if (peliculasFiltrarDTO.EnCines)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCines);
            }

            if (peliculasFiltrarDTO.ProximosEstrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(x => x.FechaLanzamiento > hoy);
            }

            if (peliculasFiltrarDTO.GeneroId != 0)
            {
                peliculasQueryable = peliculasQueryable
                    .Where(x => x.PeliculasGeneros.Select(y => y.GeneroId)
                    .Contains(peliculasFiltrarDTO.GeneroId));
            }

            await HttpContext.InsertarParametrosPaginacionCabecera(peliculasQueryable);

            var peliculas = await peliculasQueryable.Paginar(peliculasFiltrarDTO.PaginacionDTO).ToListAsync();
            return mapper.Map<List<PeliculasDTO>>(peliculas);
        }

        // POST api/<PeliculasController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] PeliculasCreacionDTO PeliculaCreacionDto)
        {

            if (PeliculaCreacionDto.Titulo != "undefined")
            {
                Peliculas Pelicula = mapper.Map<Peliculas>(PeliculaCreacionDto);


                if (PeliculaCreacionDto.Poster != null)
                {
                    //para azure
                    Pelicula.Poster = await almacenadorArchivos.GuardarArchivo(contenedor, PeliculaCreacionDto.Poster);
                }

                EscribirOrdenActores(Pelicula);

                _context.Add(Pelicula);
                await _context.SaveChangesAsync();

                return Pelicula.Id;
            }

            return NoContent();//204 

        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<PeliculasPostGetDTO>> PostGet()
        {
            var cines = await _context.Cines.ToListAsync();
            var generos = await _context.Generos.ToListAsync();

            var cinesDTO = mapper.Map<List<CinesDTO>>(cines);
            var generosDTO = mapper.Map<List<GenerosDTO>>(generos);

            return new PeliculasPostGetDTO() { Cines = cinesDTO, Generos = generosDTO };
        }

        [HttpGet("PutGet/{id:int}")]
        public async Task<ActionResult<PeliculasPutGetDTO>> PutGet(int id)
        {

            var peliculaActionResult = await Get(id);
            if (peliculaActionResult.Result is NotFoundResult)
            {
                return NotFound();
            }

            var pelicula = peliculaActionResult.Value;

            var generosSeleccionadosIds = pelicula.Generos.Select(x => x.Id).ToList();
            var generosNoSeleccionados = await _context.Generos
                .Where(x => !generosSeleccionadosIds.Contains(x.Id))
                .ToListAsync();

            var cinesSeleccionadosIds = pelicula.Cines.Select(x => x.Id).ToList();
            var cinesNoSeleccionados = await _context.Cines
                .Where(x => !cinesSeleccionadosIds.Contains(x.Id))
                .ToListAsync();

            var generosNoSeleccionadosDTo = mapper.Map<List<GenerosDTO>>(generosNoSeleccionados);
            var cinesNoSeleccionadosDTo = mapper.Map<List<CinesDTO>>(cinesNoSeleccionados);

            var respuesta = new PeliculasPutGetDTO();
            respuesta.Pelicula = pelicula;
            respuesta.GenerosNoSeleccionados = generosNoSeleccionadosDTo;
            respuesta.GenerosSeleccionados = pelicula.Generos;

            respuesta.CinesNoSeleccionados = cinesNoSeleccionadosDTo;
            respuesta.CinesSeleccionados = pelicula.Cines;
            respuesta.Actores = pelicula.Actores;

            return respuesta;

        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int Id, [FromForm] PeliculasCreacionDTO PeliculaCreacionDto)
        {
            try
            {
                PeliculaCreacionDto.Id = Id;
                Peliculas Pelicula = await _context.Peliculas
                    .Include(x => x.PeliculasActores)
                    .Include(x => x.PeliculasGeneros)
                    .Include(x => x.PeliculasCines)
                    .FirstOrDefaultAsync(x => x.Id == Id);

                if (Pelicula == null)
                {
                    NotFound();
                }

                var peli = Pelicula;

                Pelicula = mapper.Map(PeliculaCreacionDto, Pelicula);

                if (PeliculaCreacionDto.Poster != null)
                {
                    //para azure
                    Pelicula.Poster = await almacenadorArchivos.EditarArchivo(contenedor, PeliculaCreacionDto.Poster, Pelicula.Poster);
                }

                EscribirOrdenActores(Pelicula);

                await _context.SaveChangesAsync();
                return NoContent();//204 
            }
            catch (Exception Ex)
            {

                throw;
            }

        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var pelicula = await _context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);

                if (pelicula == null)
                {
                    return NotFound();
                }

                _context.Remove(pelicula);
                await _context.SaveChangesAsync();

                await almacenadorArchivos.BorrarArchivo(pelicula.Poster, contenedor);

                return NoContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //guardar el orden quenque vinieron los actores
        private void EscribirOrdenActores(Peliculas pelicula)
        {

            if (pelicula.PeliculasActores != null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i;

                }
            }
        }
    }
}
