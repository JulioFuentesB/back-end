using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Repositorio;
using back_end.Utilidades;
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
    public class PeliculasController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly ILogger<PeliculasController> Logger;
        private readonly ApplicationDbContext _context;

        private readonly string contenedor = "Peliculas";

        public PeliculasController(
             ILogger<PeliculasController> logger
            , ApplicationDbContext context
            , IMapper mapper
            , IAlmacenadorArchivos almacenadorArchivos
            )
        {

            Logger = logger;
            _context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
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
        public async Task<ActionResult<PeliculasDTO>> Get(int id)
        {
            var pelicula = await _context.Peliculas
                //asu vez traer el genero
                .Include(x => x.PeliculasGeneros).ThenInclude(x => x.Generos)
                .Include(x => x.PeliculasActores).ThenInclude(x => x.Actores)
                .Include(x => x.PeliculasCines).ThenInclude(x => x.Cines)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null) { return NotFound(); }

            var dto = mapper.Map<PeliculasDTO>(pelicula);
            dto.Actores = dto.Actores.OrderBy(x => x.Orden).ToList();
            return dto;
        }



        // POST api/<PeliculasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PeliculasCreacionDTO PeliculaCreacionDto)
        {

            if (PeliculaCreacionDto.Titulo != "undefined")
            {
                var Pelicula = mapper.Map<Peliculas>(PeliculaCreacionDto);


                if (PeliculaCreacionDto.Poster != null)
                {
                    //para azure
                    Pelicula.Poster = await almacenadorArchivos.GuardarArchivo(contenedor, PeliculaCreacionDto.Poster);
                }

                EscribirOrdenActores(Pelicula);

                _context.Add(Pelicula);
                await _context.SaveChangesAsync();
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
            respuesta.GenerosSeleccionados = generosNoSeleccionadosDTo;
            respuesta.GenerosSeleccionados = pelicula.Generos;

            respuesta.CinesSeleccionados = cinesNoSeleccionadosDTo;
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
                    .Include(x=>x.PeliculasActores)
                    .Include(x => x.PeliculasGeneros)
                    .Include(x => x.PeliculasCines)
                    .FirstOrDefaultAsync(x => x.Id == Id);

                if (Pelicula == null)
                {
                    NotFound();
                }

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
            // var existe= await _context.Peliculas.AnyAsync(x => x.Id == id);
            var Pelicula = await _context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);


            //if (!existe)
            if (Pelicula == null)
            {
                return NotFound();
            }

            _context.Remove(new Peliculas() { Id = id });
            await _context.SaveChangesAsync();

            //  await almacenadorArchivos.BorrarArchivo(Pelicula.Foto, contenedor);
            return NoContent();//204 

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
