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
    [Route("api/ratings")]
    [ApiController]//modelo de una accion es invalido, deveulve un error a uns usario que tiene algo malo
    public class RatingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        public ILogger<GenerosController> Logger { get; }
        public ApplicationDbContext _context { get; }

        public RatingsController(
             ILogger<GenerosController> logger
            , ApplicationDbContext context
            , IMapper mapper
            , UserManager<IdentityUser> userManager
            )
        {

            Logger = logger;
            _context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] RatingDTO ratingDTO)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var usuario = await userManager.FindByEmailAsync(email);
            var usuarioId = usuario.Id;

            var ratingActual = await _context.Ratings
                .FirstOrDefaultAsync(x => x.PeliculaId == ratingDTO.PeliculaId
                && x.UsuarioId == usuarioId);

            if (ratingActual == null)
            {
                var rating = new Rating();
                rating.PeliculaId = ratingDTO.PeliculaId;
                rating.Puntuacion = ratingDTO.Puntuacion;
                rating.UsuarioId = usuarioId;
                _context.Add(rating);
            }
            else
            {
                ratingActual.Puntuacion = ratingDTO.Puntuacion;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
