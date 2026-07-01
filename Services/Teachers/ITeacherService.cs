using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public interface ITeacherService
{
    public Task AddRandomTeachersAsync();
    public Task CreateTeacherAsync(Teacher teacher);

    public Task<Teacher> GetTeacherByIdAsync(int teacherId);
    public Task<List<Teacher>> GetAllTeachersAsync();

    public Task ModifyTeacherAsync(int teacherId, Teacher teacher);

    public Task DeleteTeacherAsync(int teacherId);
}