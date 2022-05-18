using back_end.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class Genero2:IValidatableObject//validacion por modelo
    {
        /// <summary>
        /// identificador de base de datos
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido.")]
        [StringLength(maximumLength:10,ErrorMessage ="El campo no debe ser mayoa a {1}")]
        [PrimeraLetraMayuscula(ErrorMessage ="cambiando el mensaje primera letra mayuscula")]//validacion por atributo
        public string Nombre { get; set; }

        [Range(18,120)]
        public int Edad { get; set; }

        [CreditCard]
        public string TargetaDeCredito { get; set; }
        [Url]
        public string URL { get; set; }

      

        //validacion directa por que esta dentro de la clse enero y puede utilizar cualquier atributo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();


            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    //se utiliza ienumerable y con yield esta insertando un elemnto al ienumerable de una maner muy simple
                    yield return new ValidationResult("La primera letra en mayuscula", new string[] { nameof(Nombre) });

                }

            }



        }
    }



    public class Genero
    {
        /// <summary>
        /// identificador de base de datos
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo no debe ser mayoa a {1}")]
        [PrimeraLetraMayuscula(ErrorMessage = "cambiando el mensaje primera letra mayuscula")]//validacion por atributo
        public string Nombre { get; set; }

        public List<PeliculasGeneros> PeliculasGeneros { get; set; }

    }

}
