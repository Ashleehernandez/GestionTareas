using AutoMapper;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuarios, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuarios>();
            CreateMap<Usuarios , LoginDTo>();
            CreateMap<LoginDTo, Usuarios>();


            CreateMap<Tareas, TareaDTO>()
                .ForMember(dest => dest.EstudianteNombre, opt => opt.MapFrom(src => src.Estudiante.NombreCompleto))
                .ForMember(dest => dest.AdminNombre, opt => opt.MapFrom(src => src.Admin.NombreCompleto));
        }
    }
}
