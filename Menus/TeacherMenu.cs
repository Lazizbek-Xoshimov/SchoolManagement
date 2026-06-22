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

    public void SelectOption(int option)
    {
        switch (option)
        {
            case 1: AddRandomTeachersMenu(); break;
            case 2: CreateTeacherMenu(); break;
            case 3: GetTeacherByIdMenu(); break;
            case 4: GetAllTeachersMenu(); break;
            case 5: ModifyTeacherMenu(); break;
            case 6: DeleteTeacherMenu(); break;
            default: Console.WriteLine("You have selected the wrong section."); break;
        }
    }

    public void AddRandomTeachersMenu()
    {
        teacherService.AddRandomTeachers();
        Console.WriteLine("Database filled with random teacher data.");
    }

    public void CreateTeacherMenu()
    {
        Teacher teacher = new Teacher();

        Console.Write("Enter the teacher's full name: ");
        teacher.FullName = Console.ReadLine();

        Console.Write("Enter which subject teacher: ");
        teacher.Subject = Console.ReadLine();

        teacherService.CreateTeacher(teacher);
        Console.WriteLine("Teacher added to the database.");
    }

    public void GetTeacherByIdMenu()
    {
        Console.Write("Enter the teacher ID you're looking for: ");
        int teacherId = int.Parse(Console.ReadLine());

        Teacher teacher = teacherService.GetTeacherById(teacherId);

        Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
        Console.WriteLine($"Teacher's full name: {teacher.FullName}");
        Console.WriteLine($"Teacher's subject: {teacher.Subject}");
    }

    public void GetAllTeachersMenu()
    {
        List<Teacher> teachers = teacherService.GetAllTeachers();

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"Teacher's ID: {teacher.TeacherId}");
            Console.WriteLine($"Teacher's full name: {teacher.FullName}");
            Console.WriteLine($"Teacher's subject: {teacher.Subject}");
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

        teacherService.ModifyTeacher(teacherId, teacher);
        Console.WriteLine($"The teacher's information on ID {teacherId} has been changed.");
    }

    public void DeleteTeacherMenu()
    {
        Console.Write("Enter the teacher ID to be deleted: ");
        int teacherId = int.Parse(Console.ReadLine());

        teacherService.DeleteTeacher(teacherId);
        Console.WriteLine($"Teacher data with ID {teacherId} has been deleted.");
    }
}