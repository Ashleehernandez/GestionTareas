
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Repository;
using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Service;
using GestionTareas.Applicaction.GestionTareas.Service;
using GestionTareas.Infraestructura.GestionTareas.Context.DB;
using GestionTareas.Infraestructura.GestionTareas.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionTareas.Infraestructura.GestionTareas.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGestionTareasInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<ContextDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Add Repositories
            services.AddScoped(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();
            // Add Services
            services.AddScoped(typeof(IGeneryService<>), typeof(GeneryService<>));
            services.AddScoped<IAuthService, AuthService>();

            //Add Service Tarea
            services.AddScoped(typeof(IGeneryService<>), typeof(GeneryService<>));
            services.AddScoped<ITareaService , TareaService>();
            //Add Repository Tarea
            services.AddScoped(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
            services.AddScoped<ITareaRepository, TareaRepository>();
            return services;
        }
    }
}
