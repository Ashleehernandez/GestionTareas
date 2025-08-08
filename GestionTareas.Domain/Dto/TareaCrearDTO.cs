using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Domain.Dto
{
    public class TareaCrearDTO
    {
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaLimite { get; set; }

        [Required]
        public int EstudianteId { get; set; }
    }
}
