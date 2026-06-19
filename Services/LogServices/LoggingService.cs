namespace SchoolManagement.Services.LogServices;

public class LoggingService : ILoggingService
{
    private string path = @"D:\sources\repos\SchoolManagement\Logs\" + $"{DateTime.Now.Date.ToString("yyyy.MM.dd")}.log";

    public FileStream CreateLogFile()
    {
        if (File.Exists(path))
        {
            using FileStream fileStream = new FileStream(path + $"{DateTime.Now.Date.ToString("yyyy.MM.dd")}.log", FileMode.Append);
            return fileStream;
        }

        using FileStream fileStreamOpen = new FileStream(path + $"{DateTime.Now.Date.ToString("yyyy.MM.dd")}.log", FileMode.CreateNew);
        return fileStreamOpen;
    }

    public void WriteLogs(string mode)
    {
        using StreamWriter streamWriter = new StreamWriter(path, append: true);
        streamWriter.WriteLine($"[{DateTime.Now.TimeOfDay}] mode: {mode}");
    }
}