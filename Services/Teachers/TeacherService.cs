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
    Random randomString = new Random();
    
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
    }
    public void AddRandomTeachers()
    {
        for (int i = 0; i < 10; i++)
        {
            Teacher teacher = new Teacher();

            teacher.FullName = teacherFullNames[randomString.Next(10)];
            teacher.Subject = teacherSubjects[randomString.Next(10)];

            CreateTeacher(teacher);
        }
    }

    public void CreateTeacher(Teacher teacher)
    {
        teacher.TeacherId = teacherRepository.GetAll().Count;

        if (teacherRepository.GetAll().Select(selectTeacher => selectTeacher.TeacherId).Contains(teacher.TeacherId))
            throw new NotFoundException("Database is empty.");

        teacherRepository.Create(teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher added to teachers.json file");
    }

    public Teacher GetTeacherById(int teacherId)
    {
        var teacher = teacherRepository.GetAll().FirstOrDefault(teacher => teacher.TeacherId == teacherId);
        
        if (teacher is null)
            throw new NotFoundException("Teacher is not found.");

        return teacher;
    }

    public List<Teacher> GetAllTeachers()
    {
        var teachers = teacherRepository.GetAll();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");

        return teacherRepository.GetAll();
    }

    public void ModifyTeacher(int teacherId, Teacher teacher)
    {
        var teachers = teacherRepository.GetAll();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");

        if (!teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
            throw new NotFoundException("Teacher is not found.");

        teacherRepository.Update(teacherId, teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher updated");
    }

    public void DeleteTeacher(int teacherId)
    {
        var teachers = teacherRepository.GetAll();

        if (teachers.Count().Equals(0)) 
            throw new NotFoundException("Database is empty.");
        
        Teacher teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);

        if (teacher is null)
            throw new NotFoundException("Teaecher is not found.");

        teacherRepository.Delete(teacher);
        logging.WriteLogs($"{teacher.TeacherId} ID teacher deleted");            
    }
}