using back_end.Entidades;
using back_end.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        public IRepositorioEnMemoria _repositorio { get; }

        public GenerosController(IRepositorioEnMemoria repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/<GenerosController>
        [HttpGet]
        public ActionResult<List<Genero>> Get()
        {

            List<Genero> generos = _repositorio.ObtenerTodosLosGeneros();

            return Ok(generos);
        }

        // GET api/<GenerosController>/5
        [HttpGet("{id}")]
        public ActionResult<Genero> Get(int id)
        {
            Genero genero = _repositorio.ObtenerPorId(id);

            if (genero==null)
            {
                NotFound();
            }

            return Ok(genero);
        }

        // POST api/<GenerosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
