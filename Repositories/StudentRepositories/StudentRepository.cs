using System.Text.Json;
using SchoolManagement.Managers;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories.StudentRepositories;

public class StudentRepository : IStudentRepository
{
    private string path;
    private string content;
    private List<Student> students;
    private int creationStudentId;

    public StudentRepository()
    {
        path = @"Data\students.json";
        content = File.ReadAllText(path);
        students = JsonSerializer.Deserialize<List<Student>>(content);

        creationStudentId = students.Count.Equals(0) ? 0 : students[students.Count - 1].StudentId + 1;
    }

    public void CreateStudent(Student student)
    {
        using StudentFileManager manager = new StudentFileManager(path);

        student.StudentId = creationStudentId ++;
        students.Add(student);
        
        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        manager.Add(data);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student GetStudentById(int studentId)
    {
        return students.FirstOrDefault(student => student.StudentId.Equals(studentId));
    }

    public void ModifyStudent(int studentId, Student student)
    {
        using StudentFileManager manager = new StudentFileManager(path);
        
        Student modifiedStudent = GetStudentById(studentId);
        int indexOfStudent = students.IndexOf(modifiedStudent);
        students.RemoveAt(indexOfStudent);

        students.Insert(indexOfStudent, student);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        manager.Add(data);
    }

    public void DeleteStudent(int studentId)
    {
        using StudentFileManager manager = new StudentFileManager(path);

        Student deletedStudent = GetStudentById(studentId);
        students.Remove(deletedStudent);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        manager.Add(data);
    }
}