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
            student.Course = random.Next(1, 5);

            this.CreateStudent(student);
        }
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student GetStudentById(int studentId)
    {
        Student returnedStudent = students.FirstOrDefault(student => student.StudentId == studentId);
        return returnedStudent;
    }

    public IEnumerable<IGrouping<bool, Student>> GetStudentsByName(string name)
    {
        var returnedStudents = students.GroupBy(student => student.FullName.Contains(name));
        return returnedStudents;
    }

    public List<Student> GetPaginatedStudents(int page, int pageSize)
    {
        List<Student> returnedStudents = students.Skip((page - 1) * 10).Take(pageSize).ToList();
        return returnedStudents;
    }

    public int GetStudentsCount()
    {
        return students.Count();
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

    public bool AddStudentRange(params Student[] studentRange)
    {
        bool isAdded = true;
        
        for(int i = 0; i < studentRange.Length; i++)
        {
            for (int j = i; j < studentRange.Length - 1; j++)
            {
                if (studentRange[i].StudentId == studentRange[j + 1].StudentId)
                    isAdded = false;
            }
        }

        if (isAdded)
            students.AddRange(studentRange);
            
        return isAdded;
    }
}