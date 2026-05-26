using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public bool CreateStudent(Student student);

    public Student[] GetAllStudents();

    public bool AddRandomStudents();
}