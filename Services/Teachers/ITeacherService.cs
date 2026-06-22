using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public interface ITeacherService
{
    public void AddRandomTeachers();
    public void CreateTeacher(Teacher teacher);

    public Teacher GetTeacherById(int teacherId);
    public List<Teacher> GetAllTeachers();

    public void ModifyTeacher(int teacherId, Teacher teacher);

    public void DeleteTeacher(int teacherId);
}