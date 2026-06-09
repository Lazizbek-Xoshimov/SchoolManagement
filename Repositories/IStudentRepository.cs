using SchoolManagement.Models;

namespace SchoolManagement.Repositories;

public interface IStudentRepository
{
    public bool CreateStudent(Student student);

    public IEnumerable<KeyValuePair<int, Student>> GetAllStudents();
    public Student GetStudentById(int studentId);

    public bool ModifyStudent(int studentId, Student student);

    public bool DeleteStudent(int studentId);
}