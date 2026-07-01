namespace SchoolManagement.Managers;

public class StudentFileManager : IDisposable
{
    private string path;
    private StreamWriter writer;

    public StudentFileManager(string path)
    {
        this.path = path;
        writer = new StreamWriter(path);
    }

    public async Task AddAsync(string data)
    {
        await writer.WriteLineAsync(data);
    }

    public void Dispose()
    {
        writer.Flush();
        writer.Close();
    }
}