using System.Text.Json;
using SchoolManagement.Models;

namespace SchoolManagement.Repositories.StudentRepositories;

public class StudentRepository : IStudentRepository
{
    private string path;
    private string content;
    private List<Student> students;
    private int studentId;

    public StudentRepository()
    {
        path = @"Data\students.json";
        content = File.ReadAllText(path);
        students = JsonSerializer.Deserialize<List<Student>>(content);

        studentId = students.Count;
    }

    public void CreateStudent(Student student)
    {
        student.StudentId = studentId ++;
        students.Add(student);
        
        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
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
        Student modifiedStudent = GetStudentById(studentId);
        int indexOfStudent = students.IndexOf(modifiedStudent);
        students.RemoveAt(indexOfStudent);

        students.Insert(indexOfStudent, student);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
    }

    public void DeleteStudent(int studentId)
    {
        Student deletedStudent = GetStudentById(studentId);
        students.Remove(deletedStudent);

        string data = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, data);
    }
}