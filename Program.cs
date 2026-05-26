using SchoolManagement.Models;
using SchoolManagement.Services.Students;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        IStudentService studentService = new StudentService();

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