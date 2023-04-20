namespace ITCenterBack.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
        Task<T> GetByIdAsync(long id);
    }
}
