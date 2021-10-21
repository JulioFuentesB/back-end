using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Filtros
{
    public class MiFiltroDeAccion : IActionFilter
    {
        public ILogger<MiFiltroDeAccion> Logger { get; }

        public MiFiltroDeAccion(ILogger<MiFiltroDeAccion> logger)
        {
            Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();

            Logger.LogInformation("Antes de la ejecucion");

        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
            Logger.LogInformation("despues  de la ejecucion");
        }

       
    }
}
