using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public interface ITeacherService
{
    public bool AddRandomTeachers();
    public bool CreateTeacher(Teacher teacher);

    public Teacher GetTeacherById(int teacherId);
    public Teacher[] GetAllTeachers();

    public bool ModifyTeacher(int teacherId, Teacher teacher);
}