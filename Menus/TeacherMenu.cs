using SchoolManagement.Models;
using SchoolManagement.Services.Teachers;

namespace SchoolManagement.Menus;

public class TeacherMenu
{
    private ITeacherService teacherService;

    public TeacherMenu()
    {
        this.teacherService = new TeacherService();
    }

    public void ShowOptions()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Teacher section.");
        Console.ResetColor();
        Console.WriteLine("1. Add random teacher information");
        Console.WriteLine("2. Add a new teacher");
        Console.WriteLine("3. Get the value of teacher by ID");
        Console.WriteLine("4. Get all teachers' information");
        Console.WriteLine("5. Change teacher information");
        Console.WriteLine("6. Delete teacher data");
    }

    public async Task SelectOptionAsync(int option)
    {
        switch (option)
        {
            case 1: await AddRandomTeachersMenuAsync(); break;
            case 2: await CreateTeacherMenuAsync(); break;
            case 3: await GetTeacherByIdMenuAsync(); break;
            case 4: await GetAllTeachersMenuAsync(); break;
            case 5: await ModifyTeacherMenuAsync(); break;
            case 6: await DeleteTeacherMenuAsync(); break;
            default: Console.WriteLine("You have selected the wrong section."); break;
        }
    }

    public async Task AddRandomTeachersMenuAsync()
    {
        await teacherService.AddRandomTeachersAsync();
        Console.WriteLine("Database filled with random teacher data.");
    }

    public async Task CreateTeacherMenuAsync()
    {
        Teacher teacher = new Teacher();

        Console.Write("Enter the teacher's full name: ");
        teacher.FullName = Console.ReadLine();

        Console.Write("Enter which subject teacher: ");
        teacher.Subject = Console.ReadLine();

        await teacherService.CreateTeacherAsync(teacher);
        Console.WriteLine("Teacher added to the database.");
    }

    public async Task GetTeacherByIdMenuAsync()
    {
        Console.Write("Enter the teacher ID you're looking for: ");
        int teacherId = int.Parse(Console.ReadLine());

        Teacher teacher = await teacherService.GetTeacherByIdAsync(teacherId);

        Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
        Console.WriteLine($"Teacher's full name: {teacher.FullName}");
        Console.WriteLine($"Teacher's subject: {teacher.Subject}");
    }

    public async Task GetAllTeachersMenuAsync()
    {
        List<Teacher> teachers = await teacherService.GetAllTeachersAsync();

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
            Console.WriteLine($"Teacher's full name: {teacher.FullName}");
            Console.WriteLine($"Teacher's subject: {teacher.Subject}");
        }
    }

    public async Task ModifyTeacherMenuAsync()
    {
        Teacher teacher = new Teacher();

        Console.Write("Enter the teacher ID to be changed: ");
        int teacherId = int.Parse(Console.ReadLine());

        Console.Write("Enter the teacher's full name: ");
        teacher.FullName = Console.ReadLine();

        Console.Write("Enter which subject teacher: ");
        teacher.Subject = Console.ReadLine();

        await teacherService.ModifyTeacherAsync(teacherId, teacher);
        Console.WriteLine($"The teacher's information on ID {teacherId} has been changed.");
    }

    public async Task DeleteTeacherMenuAsync()
    {
        Console.Write("Enter the teacher ID to be deleted: ");
        int teacherId = int.Parse(Console.ReadLine());

        await teacherService.DeleteTeacherAsync(teacherId);
        Console.WriteLine($"Teacher data with ID {teacherId} has been deleted.");
    }
}