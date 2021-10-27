using back_end.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DTOs
{
    public class GeneroCreacionDTO
    {

        //public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo no debe ser mayoa a {1}")]
        [PrimeraLetraMayuscula(ErrorMessage = "cambiando el mensaje primera letra mayuscula")]//validacion por atributo
        public string Nombre { get; set; }

    }
}
