using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository
{
    public interface IAuthRepository : IGeneryRepository<Usuarios>
    {
        Task<Usuarios> GetByEmailyPasswordAsync(string email , string PasswordHash);
    }
}
