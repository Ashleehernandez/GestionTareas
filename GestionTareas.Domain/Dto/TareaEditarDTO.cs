

using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Domain.Dto
{
    public class TareaEditarDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string Titulo { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        public DateTime? FechaLimite { get; set; } = default(DateTime?);
    }
}
