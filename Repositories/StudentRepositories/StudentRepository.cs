using System.Text.Json;
using SchoolManagement.Managers;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories.StudentRepositories;

public class StudentRepository : IStudentRepository
{
    private string path = @"Data\students.json";
    private List<Student> students = new List<Student>();

    public async Task CreateStudentAsync(Student student)
    {
        using StudentFileManager manager = new StudentFileManager(path);

        string content = await File.ReadAllTextAsync(path);
        int studentId = JsonSerializer.Deserialize<List<Student>>(content).Count.Equals(0) 
            ? 0 : students[students.Count - 1].StudentId + 1;
        
        student.StudentId = studentId ++;
        students.Add(student);
        
        string data = JsonSerializer.Serialize(students);
        await manager.AddAsync(data);
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        string content = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<List<Student>>(content);
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var students = await GetAllStudentsAsync();
        return students.FirstOrDefault(student => student.StudentId.Equals(studentId));
    }

    public async Task ModifyStudentAsync(int studentId, Student student)
    {
        using StudentFileManager manager = new StudentFileManager(path);
        
        Student modifiedStudent = await GetStudentByIdAsync(studentId);
        int indexOfStudent = students.IndexOf(modifiedStudent);
        students.RemoveAt(indexOfStudent);

        students.Insert(indexOfStudent, student);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        await manager.AddAsync(data);
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        using StudentFileManager manager = new StudentFileManager(path);

        Student deletedStudent = await GetStudentByIdAsync(studentId);
        students.Remove(deletedStudent);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        await manager.AddAsync(data);
    }
}