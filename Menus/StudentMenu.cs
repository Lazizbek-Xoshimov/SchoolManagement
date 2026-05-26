using SchoolManagement.Models;
using SchoolManagement.Services.Students;

namespace SchoolManagement.Menus;

public class StudentMenu
{
    IStudentService studentService = new StudentService();
    
    public void ShowOptions()
    {
        Console.WriteLine("Welcome to the student section.");
        Console.WriteLine("1. Add a random student row");
        Console.WriteLine("2. Add student information");
        Console.WriteLine("3. View student information");
        Console.WriteLine("4. View student information by ID");
        Console.WriteLine("5. Change the student value");
        Console.WriteLine("6. Delete student data");
    }

    public void AddRandomStudentsMenu()
    {
        bool isAdded = studentService.AddRandomStudents();

        if (isAdded)
            Console.WriteLine("The database was filled with random students.");
        else
            Console.WriteLine("Data not added to database. Database is full.");
    }

    public void CreateStudentMenu()
    {
        Student student = new Student();

        Console.WriteLine($"Enter student's details.");
        Console.Write("Enter student's full name: ");
        student.FullName = Console.ReadLine();

        Console.Write("Enter student's age: ");
        student.Age = int.Parse(Console.ReadLine());

        bool isAdded = studentService.CreateStudent(student);

        if (isAdded)
            Console.WriteLine("Data added to the database.");
        else 
            Console.WriteLine("Data not added to database. Database is full.");
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

    public void GetStudentsByIdMenu()
    {
        Console.Write("Enter the ID of the student you want to get information about: ");
        int studentId = int.Parse(Console.ReadLine());

        Student student = studentService.GetStudentById(studentId);

        if (student is null)
            Console.WriteLine($"No student with ID {studentId} found.");
        else
        {
            Console.WriteLine(
                $"""
                StudentId: {student.StudentId}
                Student full name: {student.FullName}
                Student phone number: {student.Age}
                """);
        }
    }

    public void ModifyStudentMenu()
    {
        Student student = new Student();

        Console.Write("Enter the student ID you want to change: ");
        int studentId = int.Parse(Console.ReadLine());

        Console.Write("Enter student's full name: ");
        student.FullName = Console.ReadLine();

        Console.Write("Enter student's age: ");
        student.Age = int.Parse(Console.ReadLine());

        bool isModified = studentService.ModifyStudent(studentId, student);

        if (isModified)
            Console.WriteLine($"Student data in index {studentId} has been changed.");
        else
            Console.WriteLine($"No student with this {studentId} was found.");
    }

    public void DeleteStudentMenu()
    {
        Console.Write("Enter the student ID to be deleted: ");
        int studentId = int.Parse(Console.ReadLine());

        bool isDeleted = studentService.DeleteStudent(studentId);

        if (isDeleted)
            Console.WriteLine($"Student information in {studentId}nd row has been deleted.");
        else
            Console.WriteLine($"No student with this {studentId} was found.");
    }
}