using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class PeliculasDTO
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Poster { get; set; }
        public List<GenerosDTO> Generos { get; set; }
        public List<PeliculaActorDTO> Actores { get; set; }
        public List<CinesDTO> Cines { get; set; }
    }

}
