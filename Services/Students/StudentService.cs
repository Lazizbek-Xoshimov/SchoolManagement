using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private Student[] students = new Student[10];
    private int indexOfStudent = 0;

    public void CreateStudent(Student student)
    {
        if (indexOfStudent < 10)
        {
            student.StudentId = indexOfStudent;
            students[indexOfStudent++] = student;
        }
        else
            Console.WriteLine("Database is full.");
    }

    public Student[] GetAllStudents()
    {
        return students;
    }

    public bool AddRandomStudents()
    {
        string[] fullNames = 
        {
            "Alexander Thompson", 
            "Olivia Martinez",
            "Daniel Robinson",
            "Sophia Carter",
            "Benjamin Lewis",
            "Isabella Walker",
            "Matthew Hall",
            "Charlotte Young",
            "Christopher Allen",
            "Amelia King"
        };

        for (int i = 0; i < 10; i++)
        {
            Student student = new Student();
            Random random = new Random();

            student.FullName = fullNames[random.Next(9)];
            student.Age = random.Next(18, 27);

            CreateStudent(student);
        }

        return true;
    }
}