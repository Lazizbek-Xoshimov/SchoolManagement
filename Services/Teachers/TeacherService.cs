using SchoolManagement.Exceptions;
using SchoolManagement.Models;
using SchoolManagement.Repositories.Generics;
using SchoolManagement.Services.LogServices;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
    private IRepository<Teacher> teacherRepository;
    private ILoggingService logging;
    private string[] teacherFullNames;
    private string[] teacherSubjects;
    Random randomString;
    
    public TeacherService()
    {
        this.teacherRepository = new Repository<Teacher>();
        this.logging = new LoggingService();
        this.teacherFullNames =
        [
            "James Anderson",
            "Emily Johnson",
            "Michael Brown",
            "Sophia Davis",
            "William Miller",
            "Olivia Wilson",
            "Benjamin Moore",
            "Charlotte Taylor",
            "Daniel Thomas",
            "Isabella White"
        ];
        this.teacherSubjects =
        [
            "Mathematics",
            "Physics",
            "Chemistry",
            "Biology",
            "English Literature",
            "History",
            "Geography",
            "Computer Science",
            "Physical Education",
            "Art and Design"
        ];

        this.randomString = new Random();
    }
    public async Task AddRandomTeachersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            Teacher teacher = new Teacher();

            teacher.FullName = teacherFullNames[randomString.Next(10)];
            teacher.Subject = teacherSubjects[randomString.Next(10)];

            await CreateTeacherAsync(teacher);
        }
    }

    public async Task CreateTeacherAsync(Teacher teacher)
    {
        var teachers = await teacherRepository.GetAllAsync();
        teacher.TeacherId = teachers.Count();

        if (teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacher.TeacherId))
            throw new NotFoundException("Database is empty.");

        await teacherRepository.CreateAsync(teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher added to teachers.json file");
    }

    public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
    {
        var teachers = await teacherRepository.GetAllAsync();
        var teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);
        
        if (teacher is null)
            throw new NotFoundException("Teacher is not found.");

        return teacher;
    }

    public async Task<List<Teacher>> GetAllTeachersAsync()
    {
        var teachers = await teacherRepository.GetAllAsync();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");

        return teachers;
    }

    public async Task ModifyTeacherAsync(int teacherId, Teacher teacher)
    {
        var teachers = await teacherRepository.GetAllAsync();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");

        if (!teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
            throw new NotFoundException("Teacher is not found.");

        await teacherRepository.UpdateAsync(teacherId, teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher updated");
    }

    public async Task DeleteTeacherAsync(int teacherId)
    {
        var teachers = await teacherRepository.GetAllAsync();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");
        
        Teacher teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);

        if (teacher is null)
            throw new NotFoundException("Teaecher is not found.");

        await teacherRepository.DeleteAsync(teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher deleted");            
    }
}