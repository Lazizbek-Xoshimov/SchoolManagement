namespace SchoolManagement.Repositories.Generics;

public class Repository<T> : IRepository<T> where T: class
{
    private Dictionary<int, T> data;
    private int index;

    public Repository()
    {
        this.data = new Dictionary<int, T>();
        index = 0;
    }

    public void Create(T value)
    {
        data.Add(index ++, value);
    }

    public Dictionary<int, T> GetAll()
    {
        return data;
    }

    public T GetById(int id)
    {
        return data[id];
    }

    public void Update(int id, T value)
    {
        data[id] = value;
    }

    public void Delete(int id)
    {
        data.Remove(id);
    }
}