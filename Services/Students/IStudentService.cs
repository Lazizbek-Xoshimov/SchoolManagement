using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public bool CreateStudent(Student student);
    public void AddRandomStudents();
    public bool AddStudentRange(params Student[] studentsRange);

    public List<Student> GetAllStudents();
    public Student GetStudentById(int studentId);
    public List<Student> GetStudentsByName(string name);
    public List<Student> GetPaginatedStudents(int page, int pageSize);
    public int GetStudentsCount();

    public bool ModifyStudent(int studentId, Student student);

    public bool DeleteStudent(int studentId);
}