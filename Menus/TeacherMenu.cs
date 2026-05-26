using SchoolManagement.Models;
using SchoolManagement.Services.Teachers;

namespace SchoolManagement.Menus;

public class TeacherMenu
{
    ITeacherService teacherService = new TeacherService();

    public void Showoptions()
    {
        Console.WriteLine("Welcome to the teacher section.");
        Console.WriteLine("1. Add a new teacher");
    }

    public void CreateTeacherMenu()
    {
        Teacher teacher = new Teacher();

        Console.Write("Enter the teacher's full name: ");
        teacher.FullName = Console.ReadLine();

        Console.Write("Enter which subject teacher: ");
        teacher.Subject = Console.ReadLine();

        bool isAdded = teacherService.CreateTeacher(teacher);

        if (isAdded)
            Console.WriteLine("Teacher added to the database.");
        else
            Console.WriteLine("Database is full.");
    }
}