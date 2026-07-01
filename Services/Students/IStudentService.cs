using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public interface IStudentService
{
    public Task CreateStudentAsync(Student student);
    public Task AddRandomStudentsAsync();
    public Task AddStudentRangeAsync(params Student[] studentsRange);

    public Task<IEnumerable<IGrouping<int, Student>>> GetAllStudentsAsync();
    public Task<Student> GetStudentByIdAsync(int studentId);
    public Task<IEnumerable<IGrouping<bool, Student>>> GetStudentsByNameAsync(string name);
    public Task<IEnumerable<Student>> GetPaginatedStudentsAsync(int page, int pageSize);
    public Task<int> GetStudentsCountAsync();
    public Task<IDictionary<int, Student>> GetCleverStudentAsync();
    public Task<IDictionary<int, Student>> GetYoungestStudentAsync();

    public Task ModifyStudentAsync(int studentId, Student student);

    public Task DeleteStudentAsync(int studentId);
}