namespace SchoolManagement.Repositories.Generics;

public interface IRepository<T>
{
    public void Create(T value);
    public List<T> GetAll();
    public void Update(int id, T value);
    public void Delete(T value);
}