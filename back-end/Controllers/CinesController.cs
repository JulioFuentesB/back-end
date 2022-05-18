using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
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

        [HttpGet]//   api/Actores
        public async Task<ActionResult<List<CinesDTO>>> GetAsync([FromQuery] PaginacionDTO paginacionDTO)
        {

            var queryable = _context.Cines.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionCabecera(queryable);
            var cines = queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO);

            return Ok(mapper.Map<List<CinesDTO>>(cines));
        }

        [HttpGet("{id:int}")]
        //se le dice que el nombre es requerido
        public async Task<ActionResult<CinesDTO>> GetAsync(int id)
        {
            Cine cine = await _context.Cines.FirstOrDefaultAsync(x => x.Id == id);

            if (cine == null)
            {
                NotFound();
            }

            return Ok(mapper.Map<CinesDTO>(cine));

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CineCreacionDTO cineCreacionDto)
        {

            var genero = mapper.Map<Cine>(cineCreacionDto);

            _context.Add(genero);
            await _context.SaveChangesAsync();
            return NoContent();//204 

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int Id, [FromBody] CineCreacionDTO cineCreacionDto)
        {

            Cine genero = await _context.Cines.FirstOrDefaultAsync(x => x.Id == Id);

            if (genero == null)
            {
                NotFound();
            }

            genero = mapper.Map(cineCreacionDto, genero);
            await _context.SaveChangesAsync();
            return NoContent();//204 

        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Cines.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            _context.Remove(new Cine() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();//204 

        }

    }
}
