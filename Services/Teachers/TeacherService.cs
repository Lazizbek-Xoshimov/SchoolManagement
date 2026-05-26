using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
    Teacher[] teachers = new Teacher[10];
    private int indexOfTeacher = 0;

    public bool AddRandomTeachers()
    {
        if (indexOfTeacher < teachers.Length)
        {
            Random randomString = new Random();

            string[] teacherFullNames =
            {
                "James Anderson",
                "Emily Johnson",
                "Michael Brown",
                "Sophia Davis",
                "William Miller",
                "Olivia Wilson",
                "Benjamin Moore",
                "Charlotte Taylor",
                "Daniel Thomas",
                "Isabella White"
            };

            string[] teacherSubjects =
            {
                "Mathematics",
                "Physics",
                "Chemistry",
                "Biology",
                "English Literature",
                "History",
                "Geography",
                "Computer Science",
                "Physical Education",
                "Art & Design"
            };

            for (int i = indexOfTeacher; i < teachers.Length; i++)
            {
                Teacher teacher = new Teacher();

                teacher.FullName = teacherFullNames[randomString.Next(10)];
                teacher.Subject = teacherSubjects[randomString.Next(10)];

                CreateTeacher(teacher);
            }

            return true;
        }
        
        return false;
    }

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

    public Teacher GetTeacherById(int teacherId)
    {
        if (teacherId >= 0 && teacherId <= indexOfTeacher)
        {
            Teacher teacher = teachers[teacherId];
            return teacher;
        }

        return null;
    }
}