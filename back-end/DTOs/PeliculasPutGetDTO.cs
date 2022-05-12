using System.Collections.Generic;

namespace back_end.DTOs
{
    public class PeliculasPutGetDTO
    {
        public PeliculasDTO Pelicula { get; set; }
        public List<GenerosDTO>  GenerosSeleccionados { get; set; }
        public List<GenerosDTO> GenerosNoSeleccionados { get; set; }

        public List<CinesDTO> CinesSeleccionados { get; set; }
        public List<CinesDTO> CinesNoSeleccionados { get; set; }

        public List<PeliculaActorDTO> Actores { get; set; }


    }

}
