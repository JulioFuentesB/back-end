using back_end.DTOs;
using System.Linq;

namespace back_end.Utilidades
{
   
        public static class IQueryableExtebsions
        {
            public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
            {
                return queryable
                    .Skip((paginacion.Pagina - 1) * paginacion.RecordsPorPagina)
                    .Take(paginacion.RecordsPorPagina);

            }
        }

    
}
