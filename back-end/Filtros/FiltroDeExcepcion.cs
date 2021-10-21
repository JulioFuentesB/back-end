using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Filtros
{
    public class FiltroDeExcepcion : ExceptionFilterAttribute
    {

        public ILogger<MiFiltroDeAccion> logger { get; }

        public FiltroDeExcepcion(ILogger<MiFiltroDeAccion> Logger)
        {
            logger = Logger;
        }


        public override void OnException(ExceptionContext context)
        {
            //loguea todos los errores en el log de excepcion asi no tengan el try cachth
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }


    }
}
