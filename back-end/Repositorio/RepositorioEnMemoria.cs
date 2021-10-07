using back_end.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositorio
{
    public class RepositorioEnMemoria: IRepositorioEnMemoria
    {
        private List<Genero> _generos;


        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){ Id=1 ,Nombre="Comedia"},
                new Genero(){ Id=2 ,Nombre="Accion"}
            };
        }


        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public Genero ObtenerPorId(int id)
        {
            return _generos.FirstOrDefault(x=>x.Id==id);
        }


    }

    public interface IRepositorioEnMemoria
    {
        List<Genero> ObtenerTodosLosGeneros();
        Genero ObtenerPorId(int id);
    }
}
