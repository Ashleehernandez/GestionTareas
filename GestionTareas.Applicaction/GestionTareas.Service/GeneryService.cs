using GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery;

namespace GestionTareas.Applicaction.GestionTareas.Service
{
    public class GeneryService<T> : IGeneryService<T> where T : class

    {
        private readonly IGeneryRepository<T> _repository;
        public GeneryService(IGeneryRepository<T> repository)
        {
            _repository = repository;
        }

        public  Task CreateAsync(T entity)
        {
            try
            {
                return  _repository.AddAsync(entity);
               
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la entidad", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try { 
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las entidades", ex);
            }

        }

        public async Task<T> GetByIdAsync(int id)
        {
            try { 
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la entidad por ID", ex);
            }
        }

        public async Task RemoveAsync(int id)
        { 
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("La entidad no existe en la base de datos");
            }
            try
            {
                await _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la entidad", ex);

            }
           
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
               return  await _repository.UpdateAsyncc(entity);
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al editar ");
            }

        }
    }
}
