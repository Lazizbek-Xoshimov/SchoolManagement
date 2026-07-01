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

    public async Task CreateStudentAsync(Student student)
    {
        await studentRepository.CreateStudentAsync(student);
        logging.WriteLogs($"{student.StudentId} ID student added to students.json file");
    }

    public async Task AddRandomStudentsAsync()
    {
        Random random = new Random();

        for (int i = 0; i < 10; i ++)
        {
            Student student = new Student();

            student.FullName = fullNames[random.Next(10)];
            student.Age = random.Next(18, 27);
            student.Grade = random.Next(1, 5);
            student.Course = random.Next(1, 5);

            await CreateStudentAsync(student);
        }
    }

    public async Task<IEnumerable<IGrouping<int, Student>>> GetAllStudentsAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();
        var studentCollection = students.GroupBy(student => student.Course);

        if (studentCollection.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return studentCollection;
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (!students.Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        return await studentRepository.GetStudentByIdAsync(studentId);
    }

    public async Task<IEnumerable<IGrouping<bool, Student>>> GetStudentsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Name must not be empty.");

        var students = await studentRepository.GetAllStudentsAsync();

        if (students.Count.Equals(0))
            throw new NotFoundException("Database is empty.");

        if (!students.Select(student => student.FullName).Contains(name))
            throw new NotFoundException("Students are not found.");

        return students.GroupBy(student => student.FullName.Contains(name));
    }

    public async Task<IEnumerable<Student>> GetPaginatedStudentsAsync(int page, int pageSize)
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.Paginate(page, pageSize);
    }

    public async Task<int> GetStudentsCountAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();
        var studentCount = students.Count();
        
        if (studentCount.Equals(0))
            throw new NotFoundException("Database is empty");

        return studentCount;
    }

    public async Task ModifyStudentAsync(int studentId, Student student)
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (!students.Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        Student modifiedStudent = await studentRepository.GetStudentByIdAsync(studentId);

        modifiedStudent.FullName = student.FullName;
        modifiedStudent.Age = student.Age;
        modifiedStudent.Course = student.Course;

        if (string.IsNullOrWhiteSpace(modifiedStudent.FullName))
            throw new ValidationException("Full Name must not be empty."); 

        await studentRepository.ModifyStudentAsync(studentId, modifiedStudent);
        logging.WriteLogs($"{studentId} ID student updated");
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (!students.Select(student => student.StudentId).Contains(studentId))
            throw new NotFoundException("Student is not found.");

        await studentRepository.DeleteStudentAsync(studentId);
        logging.WriteLogs($"{studentId} ID student deleted from students.json file");
    }

    public async Task AddStudentRangeAsync(params Student[] studentRange)
    {        
        if (studentRange.Count().Equals(0))
            throw new ValidationException("Student range must not be empty.");

        Student sameStudent = studentRange.Aggregate((first, second) => first.StudentId.Equals(second.StudentId) ? first : null);

        if (sameStudent is not null)
            throw new ValidationException("Student id shouldn't be the same.");

        var students = await studentRepository.GetAllStudentsAsync();

        foreach (var student in students)
        {
            await CreateStudentAsync(student);
        }
    }

    public async Task<IDictionary<int, Student>> GetCleverStudentAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.FindFirstOrDefaultCleverStudent();
    }

    public async Task<IDictionary<int, Student>> GetYoungestStudentAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();

        if (students.Count().Equals(0))
            throw new NotFoundException("Database is empty.");

        return students.FindFirstOrDefaultYoungestStudent();
    }
}