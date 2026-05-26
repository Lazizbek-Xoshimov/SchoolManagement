using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private Student[] students = new Student[10];
    private int indexOfStudent = 0;

    public bool CreateStudent(Student student)
    {
        if (indexOfStudent < students.Length)
        {
            student.StudentId = indexOfStudent;
            students[indexOfStudent++] = student;

            return true;
        }

        return false;
    }

    public Student[] GetAllStudents()
    {
        return students;
    }

    public bool AddRandomStudents()
    {
        if (indexOfStudent < students.Length)
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

            for (int i = indexOfStudent; i < students.Length; i++)
            {
                Student student = new Student();
                Random random = new Random();

                student.FullName = fullNames[random.Next(students.Length)];
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

    public bool DeleteStudent(int studentId)
    {
        if (studentId > 0 && studentId < indexOfStudent)
        {
            students[studentId] = null;
            Array.Resize(ref students, indexOfStudent + 1);

            return true;
        }

        return false;
    }
}