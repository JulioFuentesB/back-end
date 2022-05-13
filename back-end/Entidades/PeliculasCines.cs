using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class PeliculasCines
    {
        public int PeliculasId { get; set; }
        public int CineId { get; set; }
        public Peliculas Peliculas { get; set; }
        public Cine Cines { get; set; }

    }
}
