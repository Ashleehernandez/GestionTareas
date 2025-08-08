using GestionTareas.Domain.GestionTareas.Entity.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Domain.Dto
{
    public class TareaRespuestaEstudianteDTO
    {
        [Required]
        public int TareaId { get; set; }

        public int EstudianteId { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public EstadoTarea Estado { get; set; } = EstadoTarea.Completado;


        [Required]
        public string Descripcion { get; set; }

        [Required]
        public IFormFile ArchivoPDF { get; set; }

        public DateTime? FechaCompletada { get; set; } = DateTime.MinValue;
        public int AdminId { get; set; }
    }
}
