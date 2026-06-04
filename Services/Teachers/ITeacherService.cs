using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public interface ITeacherService
{
    public void AddRandomTeachers();
    public bool CreateTeacher(Teacher teacher);

    public Teacher GetTeacherById(int teacherId);
    public List<Teacher> GetAllTeachers();

    public bool ModifyTeacher(int teacherId, Teacher teacher);

    public bool DeleteTeacher(int teacherId);
}