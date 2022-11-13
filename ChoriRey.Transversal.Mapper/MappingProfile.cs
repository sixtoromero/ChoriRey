using AdsPublisher.Application.DTO;
using AdsPublisher.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdsPublisher.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Calificacion_MicroEmpresa, Calificacion_MicroEmpresaDTO>().ReverseMap();
            CreateMap<Categorias, CategoriasDTO>().ReverseMap();
            CreateMap<CategoriasPorMicroEmpresas, CategoriasPorMicroEmpresasDTO>().ReverseMap();
            CreateMap<Clases, ClasesDTO>().ReverseMap();
            CreateMap<Clientes, ClientesDTO>().ReverseMap();
            CreateMap<Facturas, FacturasDTO>().ReverseMap();
            CreateMap<Historial_Pagos, Historial_PagosDTO>().ReverseMap();
            CreateMap<Historial_Registro, Historial_RegistroDTO>().ReverseMap();
            CreateMap<MicroEmpresas, MicroEmpresasDTO>().ReverseMap();
            CreateMap<Parametros, ParametrosDTO>().ReverseMap();
            CreateMap<Perfil_Usuario, Perfil_UsuarioDTO>().ReverseMap();
            CreateMap<Perfiles, PerfilesDTO>().ReverseMap();
            CreateMap<Planes, PlanesDTO>().ReverseMap();
            CreateMap<PQRS, PQRSDTO>().ReverseMap();
            CreateMap<Roles, RolesDTO>().ReverseMap();
            CreateMap<SubCategoria, SubCategoriaDTO>().ReverseMap();
            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();
            CreateMap<DescriptionDynamic, DescriptionDynamicDTO>().ReverseMap();
            CreateMap<Filter, FilterDTO>().ReverseMap();

        }
    }
}
