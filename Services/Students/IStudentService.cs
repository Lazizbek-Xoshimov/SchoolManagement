using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public void CreateStudent(Student student);
    public void AddRandomStudents();
    public void AddStudentRange(params Student[] studentsRange);

    public IEnumerable<IGrouping<int, Student>> GetAllStudents();
    public Student GetStudentById(int studentId);
    public IEnumerable<IGrouping<bool, Student>> GetStudentsByName(string name);
    public IEnumerable<Student> GetPaginatedStudents(int page, int pageSize);
    public int GetStudentsCount();
    public IDictionary<int, Student> GetCleverStudent();
    public IDictionary<int, Student> GetYoungestStudent();

    public void ModifyStudent(int studentId, Student student);

    public void DeleteStudent(int studentId);
}