using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using back_end.Utilidades;

namespace back_end.DTOs
{
    public class PeliculasCreacionDTO
    {

        //nt-end
        public int Id { get; set; }
        //[Required]
        //[StringLength(maximumLength: 200)]
        //public string Nombre { get; set; }
        //public string Biografia { get; set; }
        //public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(maximumLength: 300)]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; } 

        public IFormFile Poster { get; set; }

        //para deserializar el listado, metodo propio en utilidades
        [ModelBinder(BinderType =typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CinesIds { get; set; }

        //un modelo complejo
        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculaCreacionDTO>>))]
        public List<ActorPeliculaCreacionDTO> Actores { get; set; }




    }
}
