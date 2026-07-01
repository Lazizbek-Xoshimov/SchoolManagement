using System.Text.Json;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories.Generics;

public class Repository<T> : IRepository<T> where T: Teacher
{
    private string path = @"Data\teachers.json";

    public async Task CreateAsync(T value)
    {
        var objects = await GetAllAsync();
        int creationId = objects.Count.Equals(0) ? 0 : objects[objects.Count - 1].TeacherId + 1;
        value.TeacherId = creationId ++;

        objects.Add(value);

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(path, data);
    }

    public async Task<List<T>> GetAllAsync()
    {
        string content = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<List<T>>(content);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var objects = await GetAllAsync();
        return objects.FirstOrDefault(obj => obj.TeacherId.Equals(id));
    }

    public async Task UpdateAsync(int id, T value)
    {
        var objects = await GetAllAsync();
        value.TeacherId = id;
        objects[id] = value;

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(path, data);
    }

    public async Task DeleteAsync(T value)
    {
        var objects = await GetAllAsync();
        objects.Remove(value);

        string data = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(path, data);
    }
}