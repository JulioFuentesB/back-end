using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/Cines")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    public class CinesController : ControllerBase
    {
        private readonly IMapper mapper;

        public ILogger<GenerosController> Logger { get; }
        public ApplicationDbContext _context { get; }

        public CinesController(
             ILogger<GenerosController> logger
            , ApplicationDbContext context
            , IMapper mapper
            )
        {

            Logger = logger;
            _context = context;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CineCreacionDTO cineCreacionDto)
        {

            var genero = mapper.Map<Cines>(cineCreacionDto);

            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();//204 

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int Id, [FromBody] CineCreacionDTO generoCreacionDto)
        {

            Cines genero = await _context.Cines.FirstOrDefaultAsync(x => x.Id == Id);

            if (genero == null)
            {
                NotFound();
            }

            genero = mapper.Map(generoCreacionDto, genero);
            await _context.SaveChangesAsync();
            return NoContent();//204 

        }

    }
}
