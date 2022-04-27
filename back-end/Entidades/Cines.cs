﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class Cines
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:75)]
        public string Nombre { get; set; }

        //unto planeta tierra
        public Point Ubicacion { get; set; }

    }
}
