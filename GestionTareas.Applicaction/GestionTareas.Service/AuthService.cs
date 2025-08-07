
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service;
using GestionTareas.Domain.GestionTareas.Entity;

namespace GestionTareas.Applicaction.GestionTareas.Service
{
    public class AuthService : GeneryService<Usuarios>, IAuthService
    {
        private readonly IAuthRepository _authRepository;
       

        public AuthService(IAuthRepository authRepository) : base(authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<Usuarios> GetByEmailyPasswordAsync(string email, string PasswordHash)
        {
            try
            {

                return _authRepository.GetByEmailyPasswordAsync(email, PasswordHash);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por email y contraseña", ex);
            }
        }
    }
}
