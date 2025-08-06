using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service
{
    public interface IAuthService : IGeneryService<Usuarios>
    {
        Task<Usuarios> GetByEmailAsync(string email);
    }
}
