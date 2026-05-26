using SchoolManagement.Models;
using SchoolManagement.Services.Teachers;

namespace SchoolManagement.Menus;

public class TeacherMenu
{
    ITeacherService teacherService = new TeacherService();

    public void Showoptions()
    {
        Console.WriteLine("Welcome to the teacher section.");
        Console.WriteLine("1. Add random teacher information");
        Console.WriteLine("2. Add a new teacher");
        Console.WriteLine("3. Get the value of teacher by ID");
    }

    public void AddRandomTeachersMenu()
    {
        bool isAdded = teacherService.AddRandomTeachers();

        if (isAdded)
            Console.WriteLine("Database filled with random teacher data.");
        else
            Console.WriteLine("Database is full.");
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

    public void GetTeacherByIdMenu()
    {
        Console.Write("Enter the teacher ID you're looking for: ");
        int teacherId = int.Parse(Console.ReadLine());

        Teacher teacher = teacherService.GetTeacherById(teacherId);

        if (teacher is null)
            Console.WriteLine($"Teacher with ID {teacherId} not found.");
        else
        {
            Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
            Console.WriteLine($"Teacher's full name: {teacher.FullName}");
            Console.WriteLine($"Teacher's subject: {teacher.Subject}");
        }
    }
}