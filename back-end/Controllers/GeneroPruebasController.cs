using back_end.Entidades;
using back_end.Filtros;
using back_end.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace back_end.Controllers
{
    [Route("api/generosPruebas")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    public class GeneroPruebasController : ControllerBase
    {
        public IRepositorioEnMemoria _repositorio { get; }
        public WeatherForecast WeatherForecast { get; }
        public ILogger<GenerosController> Logger { get; }

        public GeneroPruebasController(IRepositorioEnMemoria repositorio,
            WeatherForecast weatherForecast//sta accediendo a una controler por inyeccion de dependencias
            , ILogger<GenerosController> logger
            )
        {
            _repositorio = repositorio;
            WeatherForecast = weatherForecast;
            Logger = logger;
        }

        // GET: api/<GenerosController>
        [HttpGet]//   api/generos
        [HttpGet("listado2")]//  api/generos/listado
        [HttpGet("/listadoGeneros2")]//  /listadoGeneros

        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult<List<Genero2>> Get()
        {

            Logger.LogInformation("Vamos a mostrar los generos ");
            List<Genero2> generos = _repositorio.ObtenerTodosLosGeneros();

            return Ok(generos);
        }

        // GET api/<GenerosController>/5
        //task una promesa de retorno un genero
        //entre parenticis esta una variable de ruta 
        [HttpGet("{id:int}")]
        //se le dice que el nombre es requerido
        public async Task<ActionResult<Genero2>> GetAsync(int id, [BindRequired] string nombre  )
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Genero2 genero = await _repositorio.ObtenerPorId(id);

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
