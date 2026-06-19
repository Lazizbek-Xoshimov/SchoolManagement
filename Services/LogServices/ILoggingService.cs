namespace SchoolManagement.Services.LogServices;

public interface ILoggingService
{
    public FileStream CreateLogFile();
    public void WriteLogs(string mode);
}