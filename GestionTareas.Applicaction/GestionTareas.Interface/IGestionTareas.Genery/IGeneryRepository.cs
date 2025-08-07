namespace GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery
{
    public interface IGeneryRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
       
    }
}
