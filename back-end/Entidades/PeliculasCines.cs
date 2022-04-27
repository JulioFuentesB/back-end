using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class PeliculasCines
    {
        public int PeliculaId { get; set; }
        public int CineId { get; set; }
        public Peliculas Peliculas { get; set; }
        public Cines Cines { get; set; }

    }
}
