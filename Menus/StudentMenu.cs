using System.Diagnostics;
using SchoolManagement.Models;
using SchoolManagement.Services.Students;

namespace SchoolManagement.Menus;

public class StudentMenu
{
    IStudentService studentService = new StudentService();
    
    public void ShowOptions()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Student section.");
        Console.ResetColor();
        Console.WriteLine("1. Add a random student row");
        Console.WriteLine("2. Add students range");
        Console.WriteLine("3. Add student information");
        Console.WriteLine("4. View student information");
        Console.WriteLine("5. View student information by ID");
        Console.WriteLine("6. Search for students by name");
        Console.WriteLine("7. Get student information on the page");
        Console.WriteLine("8. Get the number of students in the database");
        Console.WriteLine("9. Get clever student");
        Console.WriteLine("10. Get youngest student");
        Console.WriteLine("11. Change the student value");
        Console.WriteLine("12. Delete student data");
    }

    public void SelectOption(int option)
    {
        switch (option)
        {
            case 1: AddRandomStudentsMenu(); break;
            case 2: AddStudentRangeMenu(); break;
            case 3: CreateStudentMenu(); break;
            case 4: GetAllStudentsMenu(); break;
            case 5: GetStudentsByIdMenu(); break;
            case 6: GetStudentsByNameMenu(); break;
            case 7: GetPaginatedStudentsMenu(); break;
            case 8: GetStudentsCountMenu(); break;
            case 9: GetCleverStudentMenu(); break;
            case 10: GetYoungestStudentMenu(); break;
            case 11: ModifyStudentMenu(); break;
            case 12: DeleteStudentMenu(); break;
            default: Console.WriteLine("You have selected the wrong section."); break;
        }
    }

    public void AddRandomStudentsMenu()
    {
        studentService.AddRandomStudentsAsync();
        Console.WriteLine("The database was filled with random students.");
    }

    public void CreateStudentMenu()
    {
        Student student = new Student();

        Console.WriteLine($"Enter student's details."); 
        Console.Write("Enter student's full name: ");
        student.FullName = Console.ReadLine();

        Console.Write("Enter student's age: ");
        student.Age = int.Parse(Console.ReadLine());

        Console.Write("Enter the student's course: ");
        student.Course = int.Parse(Console.ReadLine());

        Console.Write("Enter the student's grade: ");
        student.Grade = int.Parse(Console.ReadLine());

        studentService.CreateStudentAsync(student);
        Console.WriteLine("Data added to the database.");
    }

    public void GetAllStudentsMenu()
    {
        foreach(var students in studentService.GetAllStudents())
        {
            Console.WriteLine($"Students in {students.Key} course: ");
            foreach(var student in students)
            {
                Console.WriteLine($"StudentId: {student.StudentId}");
                Console.WriteLine($"Student full name: {student.FullName}");
                Console.WriteLine($"Student age: {student.Age}");
                Console.WriteLine($"Student grade: {student.Grade}");
            }
            Console.WriteLine();
        }
    }

    public void GetStudentsByIdMenu()
    {
        Console.Write("Enter the ID of the student you want to get information about: ");
        int studentId = int.Parse(Console.ReadLine());

        Student student = studentService.GetStudentById(studentId);

        Console.WriteLine($"StudentId: {student.StudentId}");
        Console.WriteLine($"Student full name: {student.FullName}");
        Console.WriteLine($"Student age: {student.Age}");
        Console.WriteLine($"Student grade: {student.Grade}");
        Console.WriteLine($"Student course: {student.Course}");
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

        Console.Write("Enter student's course: ");
        student.Course = int.Parse(Console.ReadLine());

        Console.Write("Enter student's grade: ");
        student.Grade = int.Parse(Console.ReadLine());

        studentService.ModifyStudent(studentId, student);
        Console.WriteLine($"Student data in index {studentId} has been changed.");
    }

    public void DeleteStudentMenu()
    {
        Console.Write("Enter the student ID to be deleted: ");
        int studentId = int.Parse(Console.ReadLine());
        
        studentService.DeleteStudent(studentId);
        Console.WriteLine($"Student information in {studentId} ID has been deleted.");
    }

    public void GetStudentsByNameMenu()
    {
        Console.Write("Enter the name of student you are looking for: ");
        string name = Console.ReadLine();

        var studentCollection = studentService.GetStudentsByName(name);

        foreach(var students in studentCollection)
        {
            if (students.Key is true)
            {
                Console.WriteLine($"Students named {name}:");
                foreach (var student in students)
                {
                    Console.WriteLine($"StudentId: {student.StudentId}");
                    Console.WriteLine($"Student full name: {student.FullName}");
                    Console.WriteLine($"Student age: {student.Age}");
                    Console.WriteLine($"Student grade: {student.Grade}");
                    Console.WriteLine($"Student course: {student.Course}");
                    Console.WriteLine();
                }
            }
        }
    }

    public void GetPaginatedStudentsMenu()
    {
        Console.Write("Enter the page: ");
        int page = int.Parse(Console.ReadLine());

        Console.Write("Enter the page size: ");
        int pageSize = int.Parse(Console.ReadLine());

        var students = studentService.GetPaginatedStudents(page, pageSize);
        
        foreach (var student in students)
        {
            Console.WriteLine($"StudentId: {student.StudentId}");
            Console.WriteLine($"Student full name: {student.FullName}");
            Console.WriteLine($"Student age: {student.Age}");
            Console.WriteLine($"Student grade: {student.Grade}");
            Console.WriteLine($"Student course: {student.Course}");
        }
    }

    public void GetStudentsCountMenu()
    {
        int studentsCount = studentService.GetStudentsCount();
        Console.WriteLine($"There are {studentsCount} students in the database.");
    }

    public void AddStudentRangeMenu()
    {
        List<Student> studentRange = new List<Student>();
        string wantAdd = string.Empty;
        
        do
        {
            Student student = new Student();
            
            Console.WriteLine($"Enter student's details.");
            Console.Write("Enter student's ID: ");
            student.StudentId = int.Parse(Console.ReadLine());
            
            Console.Write("Enter student's full name: ");
            student.FullName = Console.ReadLine();

            Console.Write("Enter student's age: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter the student's course: ");
            student.Course = int.Parse(Console.ReadLine());

            Console.Write("Enter student's grade: ");
            student.Grade = int.Parse(Console.ReadLine());

            studentRange.Add(student);            
            
            Console.WriteLine("Do you want to add more?");
            Console.Write("(yes/no): ");
            wantAdd = Console.ReadLine();
        } while (wantAdd.Equals("yes"));

        studentService.AddStudentRange(studentRange.ToArray());
        Console.WriteLine("Students have been added to the database.");
    }

    public void GetCleverStudentMenu()
    {
        foreach (var room in studentService.GetCleverStudent())
        {
            Console.WriteLine($"{room.Value.FullName} is a clever in {room.Key} course.");
        }
    }

    public void GetYoungestStudentMenu()
    {
        foreach (var room in studentService.GetYoungestStudent())
        {
            Console.WriteLine($"{room.Value.FullName} is a youngest in {room.Key} course.");
        }
    }
}