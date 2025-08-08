using AutoMapper;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service;
using GestionTareas.Domain.Dto;
using GestionTareas.Domain.GestionTareas.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : Controller
    {
        private readonly ITareaService _tareaService;
        private readonly IMapper _mapper;
        public TareasController(ITareaService tareaService, IMapper _mapperl)
        {
            _tareaService = tareaService;
            _mapper = _mapperl;
        }

        [HttpGet("TareasByUsuarioId/{usuarioId}")]
        public async Task<IActionResult> GetTareasByUsuarioId(int usuarioId)
        {
            try
            {
                var tareas = await _tareaService.GetTareasByUsuarioIdAsync(usuarioId);
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPost("Tareas")]
       
        public async Task<IActionResult> Create([FromBody] TareaDTO tareaDto)
        {
            try
            {
                var tarea = _mapper.Map<Tareas>(tareaDto);
                await _tareaService.CreateAsync(tarea);
                return Ok(tarea);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tareas = await _tareaService.GetAllAsync();
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tareaService.RemoveAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("tareas/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TareaEditarDTO tareaDto)
        {
            try
            {
                var existingTarea = await _tareaService.GetByIdAsync(id);
                if (existingTarea == null)
                {
                    return NotFound($"La tarea con ID {id} no existe.");
                }
                
                _mapper.Map(tareaDto, existingTarea);
                await _tareaService.UpdateAsync(existingTarea);
               
                return Ok(existingTarea);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("Respuesta/Estudiante")]
        public async Task<IActionResult> CrearRespuestaEstudiante([FromForm] TareaRespuestaEstudianteDTO respuestaDto)
        {
            try
            {
                var respuesta = _mapper.Map<TareaRespuestaEstudianteDTO>(respuestaDto);
              
                 await _tareaService.CreateAsync(respuesta);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Respuesta/Estudiante/{tareaId}")]
        public async Task<IActionResult> GetRespuestasByTareaId(int tareaId)
        {
            try
            {

                var respuestas = await _tareaService.GetByIdAsync(tareaId);
                return Ok(respuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpPut("calificar")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CalificarTarea([FromForm] TareaCalificarDTO dto)
        {
            try
            {
              var existingTarea = await _tareaService.GetByIdAsync(dto.TareaId);
                if (existingTarea == null)
                {
                    return NotFound($"La tarea con ID {dto.TareaId} no existe.");
                }
                await _tareaService.CalificarTarea(dto.TareaId, dto.Calificacion, dto.EstudianteId);




                return Ok("Tarea calificada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al calificar la tarea: {ex.Message}");
            }
        }

    }
}
