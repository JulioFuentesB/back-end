﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class PeliculasPostGetDTO
    {
        public List<GenerosDTO> Generos { get; set; }
        public List<CinesDTO> Cines { get; set; }
    }
}
