using SchoolManagement.Models;
using SchoolManagement.Services.Students;

namespace SchoolManagement.Menus;

public class StudentMenu
{
    IStudentService studentService = new StudentService();

    public StudentMenu()
    {
        Console.WriteLine("Welcome to the student section.");
        Console.WriteLine("1. View student information");
        Console.WriteLine("2. Add student information");
    }

    public void CreateStudentMenu()
    {
        for (int i = 1; i <= 10; i++)
        {
            Student student = new Student();

            Console.WriteLine($"Enter student {i}'s details.");
            Console.Write("Enter student's full name: ");
            student.FullName = Console.ReadLine();

            Console.Write("Enter student's phone number: ");
            student.PhoneNumber = Console.ReadLine();

            studentService.CreateStudent(student);
        }
    }

    public void GetAllStudentsMenu()
    {
        Student[] students = studentService.GetAllStudents();
        foreach(Student item in students)
        {
            if (item is null)
                continue;
            Console.WriteLine(
                $"""
                StudentId: {item.StudentId}
                Student full name: {item.FullName}
                Student phone number: {item.PhoneNumber}

                """);
        }
    }
}