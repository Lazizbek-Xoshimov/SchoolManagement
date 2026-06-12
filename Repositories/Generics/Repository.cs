using System.Text.Json;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories.Generics;

public class Repository<T> : IRepository<T> where T: Teacher
{
    private string path;
    private string content;
    private List<T> objects;
    private int creationId;

    public Repository()
    {
        path = @"Data\teachers.json";
        content = File.ReadAllText(path);
        objects = JsonSerializer.Deserialize<List<T>>(content);

        creationId = objects.Count.Equals(0) ? 0 : objects[objects.Count - 1].TeacherId + 1;
    }

    public void Create(T value)
    {
        value.TeacherId = creationId ++;
        objects.Add(value);

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
    }

    public List<T> GetAll()
    {
        return objects;
    }

    public T GetById(int id)
    {
        return objects[id];
    }

    public void Update(int id, T value)
    {
        value.TeacherId = id;
        objects[id] = value;

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
    }

    public void Delete(T value)
    {
        objects.Remove(value);

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
    }
}