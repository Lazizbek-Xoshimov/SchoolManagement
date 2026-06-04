using SchoolManagement.Models;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
    List<Teacher> teachers = new List<Teacher>();

    public void AddRandomTeachers()
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

        for (int i = 0; i < 10; i++)
        {
            Teacher teacher = new Teacher();

            teacher.FullName = teacherFullNames[randomString.Next(10)];
            teacher.Subject = teacherSubjects[randomString.Next(10)];

            CreateTeacher(teacher);
        }
    }

    public bool CreateTeacher(Teacher teacher)
    {
        teacher.TeacherId = teachers.Count;

        if (teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacher.TeacherId))
            return false;

        teachers.Add(teacher);

        return true;
    }

    public Teacher GetTeacherById(int teacherId)
    {
        Teacher teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);
        return teacher;
    }

    public List<Teacher> GetAllTeachers()
    {
        return teachers;
    }

    public bool ModifyTeacher(int teacherId, Teacher teacher)
    {
        if (teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
        {
            teachers[teacherId].FullName = teacher.FullName;
            teachers[teacherId].Subject = teacher.Subject;

            return true;
        }

        return false;
    }

    public bool DeleteTeacher(int teacherId)
    {
        if (teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
        {
            Teacher teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);
            teachers.Remove(teacher);
            
            return true;
        }

        return false;
    }
}