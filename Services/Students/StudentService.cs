using SchoolManagement.Extensions;
using SchoolManagement.Repositories.StudentRepositories;
using SchoolManagement.Models;
using SchoolManagement.Services.LogServices;
using SchoolManagement.Exceptions;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository studentRepository;
    private ILoggingService logging;
    private string[] fullNames;

    public StudentService()
    {
        studentRepository = new StudentRepository();
        logging = new LoggingService();
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

    public void CreateStudent(Student student)
    {
        studentRepository.CreateStudentAsync(student);
        logging.WriteLogs($"{student.StudentId} ID student added to students.json file");
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

            CreateStudent(student);
        }
    }

    public IEnumerable<IGrouping<int, Student>> GetAllStudents()
    {
        var studentCollection = studentRepository.GetAllStudents().GroupBy(student => student.Course);

        if (studentCollection.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return studentCollection;
    }

    public Student GetStudentById(int studentId)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        return studentRepository.GetStudentById(studentId);
    }

    public IEnumerable<IGrouping<bool, Student>> GetStudentsByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Name must not be empty.");

        var students = studentRepository.GetAllStudents();

        if (students.Count.Equals(0))
            throw new NotFoundException("Database is empty.");

        if (!students.Select(student => student.FullName).Contains(name))
            throw new NotFoundException("Students are not found.");

        return studentRepository.GetAllStudents().GroupBy(student => student.FullName.Contains(name));
    }

    public IEnumerable<Student> GetPaginatedStudents(int page, int pageSize)
    {
        var students = studentRepository.GetAllStudents();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.Paginate(page, pageSize);
    }

    public int GetStudentsCount()
    {
        var studentCount = studentRepository.GetAllStudents().Count();
        
        if (studentCount.Equals(0))
            throw new NotFoundException("Database is empty");

        return studentCount;
    }

    public void ModifyStudent(int studentId, Student student)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        Student modifiedStudent = studentRepository.GetStudentById(studentId);

        modifiedStudent.FullName = student.FullName;
        modifiedStudent.Age = student.Age;
        modifiedStudent.Course = student.Course;

        if (string.IsNullOrWhiteSpace(modifiedStudent.FullName))
            throw new ValidationException("Full Name must not be empty."); 

        studentRepository.ModifyStudent(studentId, modifiedStudent);
        logging.WriteLogs($"{studentId} ID student updated");
    }

    public void DeleteStudent(int studentId)
    {
        if (!studentRepository.GetAllStudents().Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        studentRepository.DeleteStudent(studentId);
        logging.WriteLogs($"{studentId} ID student deleted from students.json file");
    }

    public void AddStudentRange(params Student[] studentRange)
    {        
        if (studentRange.Count().Equals(0))
            throw new ValidationException("Student range must not be empty.");

        Student sameStudent = studentRange.Aggregate((first, second) => first.StudentId.Equals(second.StudentId) ? first : null);

        if (sameStudent is not null)
            throw new ValidationException("Student id shouldn't be the same.");

        foreach (var student in studentRepository.GetAllStudents())
        {
            CreateStudent(student);
        }
    }

    public IDictionary<int, Student> GetCleverStudent()
    {
        var students = studentRepository.GetAllStudents();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.FindFirstOrDefaultCleverStudent();
    }

    public IDictionary<int, Student> GetYoungestStudent()
    {
        var students = studentRepository.GetAllStudents();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.FindFirstOrDefaultYoungestStudent();
    }
}