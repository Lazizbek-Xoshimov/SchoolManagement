using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public bool CreateStudent(Student student);
    public void AddRandomStudents();
    public bool AddStudentRange(params Student[] studentsRange);

    public IEnumerable<IGrouping<int, KeyValuePair<int, Student>>> GetAllStudents();
    public Student GetStudentById(int studentId);
    public IEnumerable<IGrouping<bool, KeyValuePair<int, Student>>> GetStudentsByName(string name);
    public IEnumerable<KeyValuePair<int, Student>> GetPaginatedStudents(int page, int pageSize);
    public int GetStudentsCount();
    public IDictionary<int, Student> GetCleverStudent();
    public IDictionary<int, Student> GetYoungestStudent();

    public bool ModifyStudent(int studentId, Student student);

    public bool DeleteStudent(int studentId);
}