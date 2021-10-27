﻿using AutoMapper;
using back_end.DTOs;
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
        private readonly IMapper mapper;

        public ILogger<GenerosController> Logger { get; }
        public ApplicationDbContext _context { get; }

        public GenerosController(
             ILogger<GenerosController> logger
            , ApplicationDbContext context
            ,IMapper  mapper
            )
        {

            Logger = logger;
            _context = context;
            this.mapper = mapper;
        }


        [HttpGet]//   api/generos

        public async Task<ActionResult<List<GenerosDTO>>> GetAsync()
        {

            List<Generos> generos = await _context.Generos.ToListAsync();

            return Ok(mapper.Map<List<GenerosDTO>>(generos));
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
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDto)
        {

            var genero = mapper.Map<Generos>(generoCreacionDto);

            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();//204

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
