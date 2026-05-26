using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
    Teacher[] teachers = new Teacher[10];
    private int indexOfTeacher = 0;

    public bool CreateTeacher(Teacher teacher)
    {
        if (indexOfTeacher >= 0 && indexOfTeacher < teachers.Length)
        {
            teacher.TeacherId = indexOfTeacher;
            teachers[indexOfTeacher ++] = teacher;
            
            return true;
        }

        return false;
    }
}