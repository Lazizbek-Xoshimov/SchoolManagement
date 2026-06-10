namespace SchoolManagement.Repositories.Generics;

public class Repository<T> : IRepository<T> where T: class
{
    private List<T> data;

    public Repository()
    {
        this.data = new List<T>();
    }

    public void Create(T value)
    {
        data.Add(value);
    }

    public List<T> GetAll()
    {
        return data;
    }

    public void Update(int id, T value)
    {
        data[id] = value;
    }

    public void Delete(T value)
    {
        data.Remove(value);
    }
}