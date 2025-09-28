

namespace GestionTareas.Domain.Dto
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
