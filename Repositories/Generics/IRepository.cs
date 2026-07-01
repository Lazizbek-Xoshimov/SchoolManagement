namespace SchoolManagement.Repositories.Generics;

public interface IRepository<T>
{
    public Task CreateAsync(T value);
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task UpdateAsync(int id, T value);
    public Task DeleteAsync(T value);
}