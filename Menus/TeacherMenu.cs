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
        Console.WriteLine("4. Get all teachers' information");
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

    public void GetAllTeachersMenu()
    {
        Teacher[] teachers = teacherService.GetAllTeachers();

        if (teachers is null)
            Console.WriteLine("There's no teacher information in the database.");
        else
        {
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
                Console.WriteLine($"Teacher's full name: {teacher.FullName}");
                Console.WriteLine($"Teacher's subject: {teacher.Subject}");
            }
        }
    }

    public void ModifyTeacherMenu()
    {
        Teacher teacher = new Teacher();

        Console.Write("Enter the teacher ID to be changed: ");
        int teacherId = int.Parse(Console.ReadLine());

        Console.Write("Enter the teacher's full name: ");
        teacher.FullName = Console.ReadLine();

        Console.Write("Enter which subject teacher: ");
        teacher.Subject = Console.ReadLine();

        bool isModified = teacherService.ModifyTeacher(teacherId, teacher);

        if (isModified)
            Console.WriteLine($"The teacher's information on ID {teacherId} has been changed.");
        else 
            Console.WriteLine($"No teacher information found for ID {teacherId}");
    }
}