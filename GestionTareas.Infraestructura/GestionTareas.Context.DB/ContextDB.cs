using GestionTareas.Domain.GestionTareas.Entity;
using GestionTareas.Domain.GestionTareas.Entity.Enum;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructura.GestionTareas.Context.DB
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

       public DbSet<Usuarios> Usuarios { get; set; }
       public DbSet<Tareas> Tareas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración Usuario
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.NombreCompleto).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.Activo).HasDefaultValue(true);

                // Restricción CHECK para Rol
                entity.HasCheckConstraint("CK_Usuario_Rol", "[Rol] IN ('Admin', 'Estudiante')");
            });

            // Configuración Tarea
            modelBuilder.Entity<Tareas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.FechaLimite).IsRequired();
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");

                // Restricción CHECK para Estado
                entity.HasCheckConstraint("CK_Tarea_Estado", "[Estado] IN ('Pendiente', 'Completada', 'Vencida')");

                // Relaciones
                entity.HasOne(t => t.Estudiante)
                      .WithMany(u => u.TareasAsignadas)
                      .HasForeignKey(t => t.EstudianteId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Tareas_Estudiante");

                entity.HasOne(t => t.Admin)
                      .WithMany(u => u.TareasCreadas)
                      .HasForeignKey(t => t.AdminId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Tareas_Admin");

               modelBuilder.Entity<Tareas>()
                .Property(t => t.Estado)
                .HasConversion<string>();

                modelBuilder.Entity<Tareas>()
                   .Property(t => t.Calificacion)
                   .HasColumnType("decimal(18,2)");
            });

            // Datos iniciales (Seed Data)
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Usuarios iniciales
            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    Id = 1,
                    NombreCompleto = "Administrador Sistema",
                    Email = "admin@admin.com",
                    PasswordHash = "$2b$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", // admin123
                    Rol = "Admin",
                    FechaRegistro = DateTime.Now,
                    Activo = true
                },
                new Usuarios
                {
                    Id = 2,
                    NombreCompleto = "Juan Carlos Pérez",
                    Email = "juan@estudiante.com",
                    PasswordHash = "$2b$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", // juan123
                    Rol = "Estudiante",
                    FechaRegistro = DateTime.Now,
                    Activo = true
                },
                new Usuarios
                {
                    Id = 3,
                    NombreCompleto = "María Elena García",
                    Email = "maria@estudiante.com",
                    PasswordHash = "$2b$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", // maria123
                    Rol = "Estudiante",
                    FechaRegistro = DateTime.Now,
                    Activo = true
                },
                new Usuarios
                {
                    Id = 4,
                    NombreCompleto = "Carlos Antonio López",
                    Email = "carlos@estudiante.com",
                    PasswordHash = "$2b$10$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi", // carlos123
                    Rol = "Estudiante",
                    FechaRegistro = DateTime.Now,
                    Activo = true
                }
            );

            // Tareas iniciales
            modelBuilder.Entity<Tareas>().HasData(
                new Tareas
                {
                    Id = 1,
                    Titulo = "Tarea de Matemáticas Avanzadas",
                    Descripcion = "Resolver los ejercicios del capítulo 5: Derivadas e Integrales",
                    FechaLimite = DateTime.Now.AddDays(10),
                    Estado = EstadoTarea.Pendiente,
                    EstudianteId = 2,
                    AdminId = 1,
                    FechaCreacion = DateTime.Now
                },
                new Tareas
                {
                    Id = 2,
                    Titulo = "Ensayo de Historia Dominicana",
                    Descripcion = "Escribir un ensayo de 1000 palabras sobre la independencia dominicana",
                    FechaLimite = DateTime.Now.AddDays(15),
                    Estado = EstadoTarea.Pendiente,
                    EstudianteId = 2,
                    AdminId = 1,
                    FechaCreacion = DateTime.Now
                },
                new Tareas
                {
                    Id = 3,
                    Titulo = "Proyecto de Ciencias Naturales",
                    Descripcion = "Realizar experimento sobre el ciclo del agua y presentar informe",
                    FechaLimite = DateTime.Now.AddDays(8),
                    Estado = EstadoTarea.Pendiente,
                    EstudianteId = 3,
                    AdminId = 1,
                    FechaCreacion = DateTime.Now
                },
                new Tareas
                {
                    Id = 4,
                    Titulo = "Traducción de Inglés",
                    Descripcion = "Traducir el texto de las páginas 45-50 del libro de inglés",
                    FechaLimite = DateTime.Now.AddDays(5),
                    Estado = EstadoTarea.Pendiente,
                    EstudianteId = 4,
                    AdminId = 1,
                    FechaCreacion = DateTime.Now
                },
                new Tareas
                {
                    Id = 5,
                    Titulo = "Análisis de Programación",
                    Descripcion = "Crear un programa en C# que implemente algoritmos de ordenamiento",
                    FechaLimite = DateTime.Now.AddDays(12),
                    Estado = EstadoTarea.Pendiente,
                    EstudianteId = 3,
                    AdminId = 1,
                    FechaCreacion = DateTime.Now.AddDays(-5),
                    FechaCompletada = DateTime.Now.AddDays(-1)
                }
            );
        }


    }
}
