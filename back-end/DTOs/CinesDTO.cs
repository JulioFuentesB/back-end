using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class CinesDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public double Latitud { get; set; }
        // [Range(-180, 180)]
        public double Longitud { get; set; }

    }
}
