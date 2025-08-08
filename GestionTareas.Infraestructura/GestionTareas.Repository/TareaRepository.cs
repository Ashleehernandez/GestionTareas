
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;
using GestionTareas.Infraestructura.GestionTareas.Context.DB;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructura.GestionTareas.Repository
{
    public class TareaRepository : GeneryRepository<Tareas>, ITareaRepository
    {
        private readonly ContextDB _context;
        public TareaRepository(ContextDB context) : base(context)
        {
            _context = context;
        }

        public async Task CalificarTarea(int tareaId, decimal calificacion, int id)
        {
            try
            {
                var tarea = await GetByIdAsync(tareaId);
                if (tarea == null)
                {
                    throw new Exception("La tarea no existe en la base de datos");
                }
                tarea.Calificacion = calificacion;
                tarea.AdminId = id;
                await _context.SaveChangesAsync();

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
                var tareaOriginal = await _context.Tareas.FindAsync(respuesta.TareaId);

                var tarea = new Tareas
                {
                    EstudianteId = respuesta.EstudianteId,
                    Calificacion = null,
                    ArchivoPDF = respuesta.ArchivoPDF,
                    Titulo = $"Respuesta: {tareaOriginal.Titulo}", // Usar título de la tarea original
                    Descripcion = $"Respuesta del estudiante a: {tareaOriginal.Descripcion}",
                    FechaCompletada = respuesta.FechaCompletada,
                    AdminId = respuesta.AdminId,
                };

                await _context.Tareas.AddAsync(tarea);
                await _context.SaveChangesAsync();
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
                return await _context.Tareas
                    .Where(t => t.EstudianteId == usuarioId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las tareas por usuario ID", ex);
            }
        }

    }
}
