using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;
using GestionTareas.Infraestructura.GestionTareas.Context.DB;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Infraestructura.GestionTareas.Repository
{
    public class GeneryRepository<T> : IGeneryRepository<T> where T : class
    {
        private readonly ContextDB _context;
        private readonly DbSet<T> _dbSet;
        public GeneryRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la entidad", ex);
            }
        }

        public async Task Delete(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity);
            if (existingEntity == null)
            {
                throw new Exception("La entidad no existe en la base de datos");
            }
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la entidad", ex);
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las entidades", ex);
            }

        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception("La entidad no existe en la base de datos");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la entidad", ex);

            }
        }

        public async Task Update(T entity)
        {
            try { 
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la entidad", ex);
            }

        }
    }
}
