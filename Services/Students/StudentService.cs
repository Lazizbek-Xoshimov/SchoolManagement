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
}