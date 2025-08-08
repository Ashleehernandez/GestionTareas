using GestionTareas.Domain.GestionTareas.Entity.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareas.Domain.GestionTareas.Entity
{
    [Table("Tareas")]
    public class Tareas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaLimite { get; set; }

        [Required]
        [StringLength(20)]
        public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int AdminId { get; set; }

        [MaxLength(500)]
        [NotMapped]
        public IFormFile ArchivoPDF  { get; set; }

        [Range(0, 100)]
        public decimal? Calificacion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaCompletada { get; set; }

        // Navegación - Estudiante
        [ForeignKey("EstudianteId")]
        public virtual Usuarios Estudiante { get; set; }

        // Navegación - Admin
        [ForeignKey("AdminId")]
        public virtual Usuarios Admin { get; set; }
    }
}
