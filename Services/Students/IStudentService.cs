using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public bool CreateStudent(Student student);
    public bool AddRandomStudents();

    public Student[] GetAllStudents();
    public Student GetStudentById(int studentId);

    public bool ModifyStudent(int studentId, Student student);

    public bool DeleteStudent(int studentId);
}