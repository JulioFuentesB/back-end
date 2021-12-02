using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //se colocan los mapeos

            CreateMap<Generos, GenerosDTO>().ReverseMap();//mapeeo de doble via 
            CreateMap<GeneroCreacionDTO, Generos>();//no tiene un reversemapeeo de doble via 

            CreateMap<Actores, ActoresDTO>().ReverseMap();//mapeeo de doble via 
            CreateMap<ActoresCreacionDTO, Actores>()
                .ForMember(x=>x.Foto, options=> options.Ignore());
        }
    }
}
