using back_end.Entidades;
using back_end.Repositorio;
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
    [Route("api/generos")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    public class GenerosController : ControllerBase
    {

        public ILogger<GenerosController> Logger { get; }
        public ApplicationDbContext _context { get; }

        public GenerosController(
             ILogger<GenerosController> logger
            , ApplicationDbContext context
            )
        {

            Logger = logger;
            _context = context;
        }


        [HttpGet]//   api/generos

        public async Task<ActionResult<List<Generos>>> GetAsync()
        {

            List<Generos> generos = await _context.Generos.ToListAsync();


            return Ok(generos);
        }

        // GET api/<GenerosController>/5
        //task una promesa de retorno un genero
        //entre parenticis esta una variable de ruta 
        [HttpGet("{id:int}")]
        //se le dice que el nombre es requerido
        public async Task<ActionResult<Genero2>> GetAsync(int id, [BindRequired] string nombre)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Genero genero = await _repositorio.ObtenerPorId(id);

            //if (genero==null)
            //{
            //    NotFound();
            //}

            return Ok();
        }

        // POST api/<GenerosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Generos genero)
        {

            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        // PUT api/<GenerosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenerosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
