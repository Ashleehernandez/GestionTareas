

using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Domain.Dto
{
    public class TareaCompletarDTO
    {
        [Required]
        public int TareaId { get; set; }
    }
}
