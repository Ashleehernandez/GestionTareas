using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository
{
    public interface ITareaRepository : IGeneryRepository<Tareas>
    {
        Task<IEnumerable<Tareas>> GetTareasByUsuarioIdAsync(int usuarioId);
        Task CalificarTarea(int tareaId, decimal calificacion , int id);
        Task CreateAsync(TareaRespuestaEstudianteDTO respuesta);
    }
}
