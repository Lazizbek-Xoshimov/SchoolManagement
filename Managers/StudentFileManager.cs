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

    public void Add(string data)
    {
        writer.WriteLine(data);
    }

    public void Dispose()
    {
        writer.Flush();
        writer.Close();
    }
}