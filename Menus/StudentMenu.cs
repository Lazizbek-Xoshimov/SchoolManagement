using SchoolManagement.Models;
using SchoolManagement.Services.Students;

namespace SchoolManagement.Menus;

public class StudentMenu
{
    IStudentService studentService = new StudentService();
    
    public void ShowOptions()
    {
        Console.WriteLine("Welcome to the student section.");
        Console.WriteLine("1. View student information");
        Console.WriteLine("2. Add student information");
        Console.WriteLine("3. Add a random student row");
    }

    public void CreateStudentMenu()
    {
        Student student = new Student();

        Console.WriteLine($"Enter student's details.");
        Console.Write("Enter student's full name: ");
        student.FullName = Console.ReadLine();

        Console.Write("Enter student's age: ");
        student.Age = int.Parse(Console.ReadLine());

        studentService.CreateStudent(student);
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
                Student phone number: {item.Age}
                """);
        }
    }

    public void AddRandomStudentsMenu()
    {
        studentService.AddRandomStudents();
        Console.WriteLine("Successful.");
    }
}