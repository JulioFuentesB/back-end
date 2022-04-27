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
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            //se colocan los mapeos

            CreateMap<Generos, GenerosDTO>().ReverseMap();//mapeeo de doble via 
            CreateMap<GeneroCreacionDTO, Generos>();//no tiene un reversemapeeo de doble via 

            CreateMap<Actores, ActoresDTO>().ReverseMap();//mapeeo de doble via 
            CreateMap<ActoresCreacionDTO, Actores>()
                .ForMember(x=>x.Foto, options=> options.Ignore());


            CreateMap<CineCreacionDTO, Cines>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));
        }
    }
}
