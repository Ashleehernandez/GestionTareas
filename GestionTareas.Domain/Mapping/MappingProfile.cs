using AutoMapper;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping For Usuarios and UsuarioDTO
            CreateMap<Usuarios, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuarios>();
            CreateMap<Usuarios , LoginDTo>();
            CreateMap<LoginDTo, Usuarios>();




           //Mapping For Tareas and TareaDTO
            CreateMap<Tareas, TareaDTO>();
            CreateMap<TareaDTO, Tareas>();
            CreateMap<Tareas, TareaEditarDTO>();
            CreateMap<TareaEditarDTO, Tareas>();
            CreateMap<Tareas, TareaRespuestaEstudianteDTO>();
            CreateMap<TareaRespuestaEstudianteDTO, Tareas>();
            CreateMap<TareaCalificarDTO , Tareas>();
            CreateMap<Tareas, TareaCalificarDTO>();
        }
    }
}
