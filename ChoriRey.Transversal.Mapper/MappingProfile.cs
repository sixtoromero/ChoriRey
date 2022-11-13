using ChoriRey.Application.DTO;
using ChoriRey.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoriRey.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();
        }
    }
}
