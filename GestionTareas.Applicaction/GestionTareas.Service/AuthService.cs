
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

        public Task<Usuarios> GetByEmailAsync(string email)
        {
            try
            {
                return _authRepository.GetByEmailAsync(email);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por email", ex);

            }
        }
    }
}
