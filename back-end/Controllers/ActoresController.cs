using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Repositorio;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/Actores")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Policy ="EsAdmin")]
    public class ActoresController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly ILogger<ActoresController> Logger;
        private readonly ApplicationDbContext _context;

        private readonly string contenedor = "actores";

        public ActoresController(
             ILogger<ActoresController> logger
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

        [HttpGet]//   api/Actores
        public async Task<ActionResult<List<ActoresDTO>>> GetAsync([FromQuery] PaginacionDTO paginacionDTO)
        {

            var queryable = _context.Actores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var Actores = queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO);

            return Ok(mapper.Map<List<ActoresDTO>>(Actores));
        }

        [HttpGet("{id:int}")]
        //se le dice que el nombre es requerido
        public async Task<ActionResult<ActoresDTO>> GetAsync(int id)
        {
            Actor actor = await _context.Actores.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                NotFound();
            }

            return Ok(mapper.Map<ActoresDTO>(actor));

        }

        // POST api/<ActoresController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActoresCreacionDTO actorCreacionDto)
        {

            if (actorCreacionDto.Nombre != "undefined")
            {
                var actor = mapper.Map<Actor>(actorCreacionDto);

                if (actorCreacionDto.Foto != null)
                {
                    //para azure
                    actor.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, actorCreacionDto.Foto);
                }

                _context.Add(actor);
                await _context.SaveChangesAsync();
            }

            return NoContent();//204 

        }

        // PUT api/<ActoresController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int Id, [FromForm] ActoresCreacionDTO actorCreacionDto)
        {
            try
            {
                actorCreacionDto.Id = Id;
                Actor actor = await _context.Actores.FirstOrDefaultAsync(x => x.Id == Id);

                if (actor == null)
                {
                    NotFound();
                }

                actor = mapper.Map(actorCreacionDto, actor);

                if (actorCreacionDto.Foto != null)
                {
                    //para azure
                    actor.Foto = await almacenadorArchivos.EditarArchivo(contenedor, actorCreacionDto.Foto, actor.Foto);
                }

                await _context.SaveChangesAsync();
                return NoContent();//204 
            }
            catch (Exception Ex)
            {

                throw;
            }

 

        }

        // DELETE api/<ActoresController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            // var existe= await _context.Actores.AnyAsync(x => x.Id == id);
            var actor = await _context.Actores.FirstOrDefaultAsync(x => x.Id == id);


            //if (!existe)
            if (actor == null)
            {
                return NotFound();
            }

            _context.Remove(new Actor() { Id = id });
            await _context.SaveChangesAsync();

            await almacenadorArchivos.BorrarArchivo(actor.Foto, contenedor);


            return NoContent();//204 

        }

        [HttpPost("buscarPorNombre")]
        public async Task<ActionResult<List<PeliculaActorDTO>>> BuscarPorNombre([FromBody] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return new List<PeliculaActorDTO>();
            }

            return await _context.Actores
                .Where(x => x.Nombre.Contains(nombre))
                .Select(x => new PeliculaActorDTO { Id = x.Id, Nombre = x.Nombre, Foto = x.Foto })
                .Take(5)
                .ToListAsync();

        }

    }
}
