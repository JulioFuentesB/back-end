using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Generos, GenerosDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Generos>();
            CreateMap<Actores, ActoresDTO>().ReverseMap();
            CreateMap<ActoresCreacionDTO, Actores>()
                .ForMember(x => x.Foto, options => options.Ignore());

            CreateMap<CineCreacionDTO, Cines>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));

            CreateMap<Cines, CinesDTO>()
                .ForMember(x => x.Latitud, dto => dto.MapFrom(campo => campo.Ubicacion.Y))
                .ForMember(x => x.Longitud, dto => dto.MapFrom(campo => campo.Ubicacion.X));

            CreateMap<PeliculasCreacionDTO, Peliculas>()
                .ForMember(x => x.Poster, opciones => opciones.Ignore())
                .ForMember(x => x.PeliculasGeneros, opciones => opciones.MapFrom(MapearPeliculasGeneros))
                .ForMember(x => x.PeliculasCines, opciones => opciones.MapFrom(MapearPeliculasCines))
                .ForMember(x => x.PeliculasActores, opciones => opciones.MapFrom(MapearPeliculasActores));

            //CreateMap<Peliculas, PeliculasDTO>()
            //    .ForMember(x => x.Generos, options => options.MapFrom(MapearPeliculasGeneros))
            //    .ForMember(x => x.Actores, options => options.MapFrom(MapearPeliculasActores))
            //    .ForMember(x => x.Cines, options => options.MapFrom(MapearPeliculasCines));

        }

        private List<CinesDTO> MapearPeliculasCines(Peliculas pelicula, PeliculasDTO peliculaDTO)
        {
            var resultado = new List<CinesDTO>();

            if (pelicula.PeliculasCines != null)
            {
                foreach (var peliculasCines in pelicula.PeliculasCines)
                {
                    resultado.Add(new CinesDTO()
                    {
                        Id = peliculasCines.CineId,
                        Nombre = peliculasCines.Cines.Nombre,
                        Latitud = peliculasCines.Cines.Ubicacion.Y,
                        Longitud = peliculasCines.Cines.Ubicacion.X
                    });
                }
            }

            return resultado;
        }

        //private List<PeliculasActoresDTO> MapearPeliculasActores(Peliculas pelicula, PeliculasDTO peliculaDTO)
        //{
        //    var resultado = new List<PeliculasActoresDTO>();

        //    if (pelicula.PeliculasActores != null)
        //    {
        //        foreach (var actorPeliculas in pelicula.PeliculasActores)
        //        {
        //            resultado.Add(new PeliculaActorDTO()
        //            {
        //                Id = actorPeliculas.ActorId,
        //                Nombre = actorPeliculas.Actor.Nombre,
        //                Foto = actorPeliculas.Actor.Foto,
        //                Orden = actorPeliculas.Orden,
        //                Personaje = actorPeliculas.Personaje
        //            });
        //        }
        //    }

        //    return resultado;
        //}

        private List<GenerosDTO> MapearPeliculasGeneros(Peliculas pelicula, PeliculasDTO peliculaDTO)
        {
            var resultado = new List<GenerosDTO>();

            if (pelicula.PeliculasGeneros != null)
            {
                foreach (var genero in pelicula.PeliculasGeneros)
                {
                    resultado.Add(new GenerosDTO() { Id = genero.GeneroId, Nombre = genero.Generos.Nombre });
                }
            }

            return resultado;
        }




        private List<PeliculasActores> MapearPeliculasActores(PeliculasCreacionDTO peliculaCreacionDTO,
            Peliculas pelicula)
        {
            var resultado = new List<PeliculasActores>();

            if (peliculaCreacionDTO.Actores == null) { return resultado; }

            foreach (var actor in peliculaCreacionDTO.Actores)
            {
                resultado.Add(new PeliculasActores() { ActorId = actor.Id, Personaje = actor.Personaje });
            }

            return resultado;
        }

        private List<PeliculasGeneros> MapearPeliculasGeneros(PeliculasCreacionDTO peliculaCreacionDTO,
            Peliculas pelicula)
        {
            var resultado = new List<PeliculasGeneros>();

            if (peliculaCreacionDTO.GenerosId == null) { return resultado; }

            foreach (var id in peliculaCreacionDTO.GenerosId)
            {
                resultado.Add(new PeliculasGeneros() { GeneroId = id });
            }

            return resultado;
        }

        private List<PeliculasCines> MapearPeliculasCines(PeliculasCreacionDTO peliculaCreacionDTO,
           Peliculas pelicula)
        {
            var resultado = new List<PeliculasCines>();

            if (peliculaCreacionDTO.CinesId == null) { return resultado; }

            foreach (var id in peliculaCreacionDTO.CinesId)
            {
                resultado.Add(new PeliculasCines() { CineId = id });
            }

            return resultado;
        }
    }
}
