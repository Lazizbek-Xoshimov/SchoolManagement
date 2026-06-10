using SchoolManagement.Models;

namespace SchoolManagement.Repositories.StudentRepositories;

public class StudentRepository : IStudentRepository
{
    private Dictionary<int, Student> students;
    private int indexOfStudent;

    public StudentRepository()
    {
        this.students = new Dictionary<int, Student>();
        indexOfStudent = 0;
    }

    public void CreateStudent(Student student)
    {
        students.Add(indexOfStudent ++, student);
    }

    public Dictionary<int, Student> GetAllStudents()
    {
        return students;
    }

    public Student GetStudentById(int studentId)
    {
        return students[studentId];
    }

    public void ModifyStudent(int studentId, Student student)
    {
        students[studentId] = student;
    }

    public void DeleteStudent(int studentId)
    {
        students.Remove(studentId);
    }
}