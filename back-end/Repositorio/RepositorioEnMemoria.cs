using back_end.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositorio
{
    public class RepositorioEnMemoria: IRepositorioEnMemoria
    {
        private List<Genero2> _generos;


        public RepositorioEnMemoria()
        {
            _generos = new List<Genero2>()
            {
                new Genero2(){ Id=1 ,Nombre="Comedia"},
                new Genero2(){ Id=2 ,Nombre="Accion"}
            };
        }


        public List<Genero2> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public async Task<Genero2> ObtenerPorId(int id)
        {
            //return  _generos.FirstOrDefault(x=>x.Id==id);
            //esperar 3 segundos de manera asincrona
            //await libera el hilo principal para que ele permita realizar mas tareas en el servidor web, tarea 
            await Task.Delay(TimeSpan.FromSeconds(1));

            return  _generos.FirstOrDefault(x => x.Id == id);
        }


    }

    public interface IRepositorioEnMemoria
    {
        List<Genero2> ObtenerTodosLosGeneros();
        Task<Genero2> ObtenerPorId(int id);
    }
}
