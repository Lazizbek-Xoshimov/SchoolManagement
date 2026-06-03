using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private List<Student> students = new List<Student>();

    public bool CreateStudent(Student student)
    {
        if (students.Select(eachStudent => eachStudent.StudentId)
                    .Contains(student.StudentId))
            return false;
        
        students.Add(student);

        return true;
    }

    public void AddRandomStudents()
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

        for (int i = 0; i < 10; i ++)
        {
            Student student = new Student();
            Random random = new Random();

            student.StudentId = students.Count();
            student.FullName = fullNames[random.Next(10)];
            student.Age = random.Next(18, 27);

            this.CreateStudent(student);
        }
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student GetStudentById(int studentId)
    {
        List<Student> returnedStudents = students.Where(student => student.StudentId == studentId).ToList();
        
        if (returnedStudents.Count == 0)
            return null;

        return returnedStudents[0];
    }

    public List<Student> GetStudentsByName(string name)
    {
        List<Student> returnedStudents = students.Where(student => student.FullName.Contains(name)).ToList();

        return returnedStudents;
    }

    public List<Student> GetPaginatedStudents(int page, int pageSize)
    {
        List<Student> returnedStudents = students.Skip((page - 1) * 10).Take(pageSize).ToList();
        return returnedStudents;
    }

    public bool ModifyStudent(int studentId, Student student)
    {
        Student modifiedStudent = this.GetStudentById(studentId);

        if (modifiedStudent is not null)
        {
            modifiedStudent.FullName = student.FullName;
            modifiedStudent.Age = student.Age;

            return true;
        }

        return false;
    }

    public bool DeleteStudent(int studentId)
    {
        bool isDeleted = false;

        Student deletedStudent = this.GetStudentById(studentId);

        if (deletedStudent is not null)
            isDeleted = students.Remove(deletedStudent);

        return isDeleted;
    }
}