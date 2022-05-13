using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class PeliculasGeneros
    {
        public int PeliculasId { get; set; }
        public int GeneroId { get; set; }
        public Peliculas Peliculas { get; set; }
        public Genero Generos { get; set; }

    }
}
