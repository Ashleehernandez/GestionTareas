

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestionTareas.Domain.GestionTareas.Entity
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = "Estudiante";

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        // Navegación - Tareas como estudiante
        public virtual ICollection<Tareas> TareasAsignadas { get; set; } = new List<Tareas>();

        // Navegación - Tareas como admin
        public virtual ICollection<Tareas> TareasCreadas { get; set; } = new List<Tareas>();
    }
}
