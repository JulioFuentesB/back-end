﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class PeliculaActorDTO
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public string Foto { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }

    }
}
