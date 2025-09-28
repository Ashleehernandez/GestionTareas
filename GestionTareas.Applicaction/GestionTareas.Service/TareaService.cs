using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Applicaction.GestionTareas.Service
{
    public class TareaService : GeneryService<Tareas>, ITareaService
    {
        private readonly ITareaRepository _tareaRepository;
        public TareaService(ITareaRepository tareaRepository) : base(tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task CalificarTarea(int tareaId, decimal calificacion, int id)
        {
            try {                 
                await _tareaRepository.CalificarTarea(tareaId, calificacion, id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calificar la tarea", ex);
            }

        }

        public async Task CreateAsync(TareaRespuestaEstudianteDTO respuesta)
        {
            try
            {
                await _tareaRepository.CreateAsync(respuesta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la respuesta de la tarea", ex);
            }

        }

        public async Task<IEnumerable<Tareas>> GetTareasByUsuarioIdAsync(int usuarioId)
        {
            try
            {
                return await _tareaRepository.GetTareasByUsuarioIdAsync(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tareas por usuario ID", ex);
            }
        }
    }
}
