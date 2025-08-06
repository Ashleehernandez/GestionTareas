using GestionTareas.Domain.GestionTareas.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructura.GestionTareas.Context.DB
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        DbSet<Usuarios> Usuarios { get; set; }
        DbSet<Tareas> Tareas { get; set; }
      
    }
}
