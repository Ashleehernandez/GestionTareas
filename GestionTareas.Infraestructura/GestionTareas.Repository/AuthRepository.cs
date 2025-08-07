using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository;
using GestionTareas.Domain.GestionTareas.Entity;
using GestionTareas.Infraestructura.GestionTareas.Context.DB;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructura.GestionTareas.Repository
{
    public class AuthRepository : GeneryRepository<Usuarios>, IAuthRepository
    {
        readonly ContextDB _context;
        readonly DbSet<Usuarios> _dbSet;
        public AuthRepository(ContextDB context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Usuarios>();

        }

        public Task<Usuarios> GetByEmailyPasswordAsync(string email, string PasswordHash)
        {
            try
            {

                return _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == PasswordHash);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por email y contraseña", ex);
            }
        }
    }
}
