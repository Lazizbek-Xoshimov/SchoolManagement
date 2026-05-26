using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public void CreateStudent(Student student);

    public Student[] GetAllStudents();
}