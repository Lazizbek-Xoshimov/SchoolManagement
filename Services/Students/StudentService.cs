using SchoolManagement.Extensions;
using SchoolManagement.Repositories.StudentRepositories;
using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository studentRepository;
    private string[] fullNames;

    public StudentService()
    {
        studentRepository = new StudentRepository();
        fullNames = 
        [
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
        ];
    }

    public bool CreateStudent(Student student)
    {
        if (studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(student.StudentId))
            return false;
        
        studentRepository.CreateStudent(student);
        return true;
    }

    public void AddRandomStudents()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i ++)
        {
            Student student = new Student();

            student.FullName = fullNames[random.Next(10)];
            student.Age = random.Next(18, 27);
            student.Grade = random.Next(1, 5);
            student.Course = random.Next(1, 5);

            studentRepository.CreateStudent(student);
        }
    }

    public IEnumerable<IGrouping<int, Student>> GetAllStudents()
    {
        var studentCollection = studentRepository.GetAllStudents().GroupBy(student => student.Course);
        return studentCollection;
    }

    public Student GetStudentById(int studentId)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            return null;

        return studentRepository.GetStudentById(studentId);
    }

    public IEnumerable<IGrouping<bool, Student>> GetStudentsByName(string name)
    {
        var students = studentRepository.GetAllStudents();

        if (students.Count.Equals(0))
            return null;

        return studentRepository.GetAllStudents().GroupBy(student => student.FullName.Contains(name));
    }

    public IEnumerable<Student> GetPaginatedStudents(int page, int pageSize)
    {
        return studentRepository.GetAllStudents().Paginate(page, pageSize);
    }

    public int GetStudentsCount()
    {
        return studentRepository.GetAllStudents().Count();
    }

    public bool ModifyStudent(int studentId, Student student)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            return false;

        Student modifiedStudent = studentRepository.GetStudentById(studentId);

        modifiedStudent.FullName = student.FullName;
        modifiedStudent.Age = student.Age;
        modifiedStudent.Course = student.Course;

        studentRepository.ModifyStudent(studentId, modifiedStudent);

        return true;
    }

    public bool DeleteStudent(int studentId)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            return false;

        studentRepository.DeleteStudent(studentId);

        return true;
    }

    public bool AddStudentRange(params Student[] studentRange)
    {        
        Student sameStudent = studentRange.Aggregate((first, second) => first.StudentId.Equals(second.StudentId) ? first : null);

        if (sameStudent is not null)
        {
            return false;   
        }

        foreach (var student in studentRepository.GetAllStudents())
        {
            CreateStudent(student);
        }

        return true;  
    }

    public IDictionary<int, Student> GetCleverStudent() =>
        studentRepository.GetAllStudents().FindFirstOrDefaultCleverStudent();

    public IDictionary<int, Student> GetYoungestStudent() =>
        studentRepository.GetAllStudents().FindFirstOrDefaultYoungestStudent();
}