using SchoolManagement.Models;

namespace SchoolManagement.Repositories.StudentRepositories;

public interface IStudentRepository
{
    public Task CreateStudentAsync(Student student);

    public Task<List<Student>> GetAllStudentsAsync();
    public Task<Student> GetStudentByIdAsync(int studentId);

    public Task ModifyStudentAsync(int studentId, Student student);

    public Task DeleteStudentAsync(int studentId);
}