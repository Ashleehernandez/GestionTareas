using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Domain.Dto
{
    public class TareaCalificarDTO
    {

        [Required]
        public int EstudianteId { get; set; }
        [Required]
        public int TareaId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public decimal Calificacion { get; set; } = 0;
    }
}
