using SchoolManagement.Models;
using SchoolManagement.Repositories.Generics;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
    private IRepository<Teacher> teacherRepository;
    private string[] teacherFullNames;
    private string[] teacherSubjects;
    Random randomString = new Random();
    
    public TeacherService()
    {
        this.teacherRepository = new Repository<Teacher>();
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
            "Art & Design"
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

    public bool CreateTeacher(Teacher teacher)
    {
        teacher.TeacherId = teacherRepository.GetAll().Count;

        if (teacherRepository.GetAll().Select(selectTeacher => selectTeacher.TeacherId).Contains(teacher.TeacherId))
            return false;

        teacherRepository.Create(teacher);

        return true;
    }

    public Teacher GetTeacherById(int teacherId)
    {
        Teacher teacher = teacherRepository.GetAll().FirstOrDefault(teacher => teacher.TeacherId == teacherId);
        return teacher;
    }

    public List<Teacher> GetAllTeachers()
    {
        return teacherRepository.GetAll();
    }

    public bool ModifyTeacher(int teacherId, Teacher teacher)
    {
        var teachers = teacherRepository.GetAll();

        if (!teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
            return false;

        teacherRepository.Update(teacherId, teacher);
        return true;
    }

    public bool DeleteTeacher(int teacherId)
    {
        var teachers = teacherRepository.GetAll();
        
        if (!teachers.Select(selectTeacher => selectTeacher.TeacherId).Contains(teacherId))
            return false;

        Teacher teacher = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherId);
        teacherRepository.Delete(teacher);
            
        return true;
    }
}