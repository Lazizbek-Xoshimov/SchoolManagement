using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private Student[] students = new Student[10];
    private int indexOfStudent = 0;

    public bool CreateStudent(Student student)
    {
        if (indexOfStudent < 10)
        {
            student.StudentId = indexOfStudent;
            students[indexOfStudent++] = student;

            return true;
        }
        else
            return false;
    }

    public Student[] GetAllStudents()
    {
        return students;
    }

    public bool AddRandomStudents()
    {
        if (indexOfStudent < 10)
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

            for (int i = indexOfStudent; i < 10; i++)
            {
                Student student = new Student();
                Random random = new Random();

                student.FullName = fullNames[random.Next(9)];
                student.Age = random.Next(18, 27);

                CreateStudent(student);
            }

            return true;
        }
        
        return false;
    }

    public bool ModifyStudent(int studentId, Student student)
    {
        if (studentId > 0 && studentId < indexOfStudent)
        {
            students[studentId].FullName = student.FullName;
            students[studentId].Age = student.Age;

            return true;
        }

        return false;
    }
}