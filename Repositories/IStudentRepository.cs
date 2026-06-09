using SchoolManagement.Models;

namespace SchoolManagement.Repositories;

public interface IStudentRepository
{
    public void CreateStudent(Student student);

    public Dictionary<int, Student> GetAllStudents();
    public Student GetStudentById(int studentId);

    public void ModifyStudent(int studentId, Student student);

    public void DeleteStudent(int studentId);
}