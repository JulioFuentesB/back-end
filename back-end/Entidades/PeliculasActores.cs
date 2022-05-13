using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class PeliculasActores
    {
        public int PeliculasId { get; set; }
        public int ActorId { get; set; }
        public Peliculas Peliculas { get; set; }
        public Actor Actores { get; set; }
        [StringLength(maximumLength:100)]
        public string Personaje { get; set; }
        public int Orden { get; set; }
        


    }
}
