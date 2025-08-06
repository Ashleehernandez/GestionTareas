namespace GestionTareas.Applicaction.GestionTareas.Interface.IGestionTareas.Genery
{
    public interface IGeneryService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);

    }
}
