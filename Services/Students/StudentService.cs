using SchoolManagement.Models;

namespace SchoolManagement.Services.Students;

public class StudentService : IStudentService
{
    private Dictionary<int, Student> students = new Dictionary<int, Student>();
    private int indexOfStudent = 0;

    public bool CreateStudent(Student student)
    {
        if (students.Keys.Contains(student.StudentId))
            return false;
        
        students.Add(indexOfStudent ++, student);

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

            student.StudentId = indexOfStudent ++;
            student.FullName = fullNames[random.Next(10)];
            student.Age = random.Next(18, 27);
            student.Course = random.Next(1, 5);

            this.CreateStudent(student);
        }
    }

    public IEnumerable<IGrouping<int, KeyValuePair<int, Student>>> GetAllStudents()
    {
        var studentCollection = students.GroupBy(student => student.Value.Course);
        return studentCollection;
    }

    public Student GetStudentById(int studentId)
    {
        Student returnedStudent = students.ContainsKey(studentId) ? students[studentId] : null;
        return returnedStudent;
    }

    public IEnumerable<IGrouping<bool, KeyValuePair<int, Student>>> GetStudentsByName(string name)
    {
        var returnedStudents = students.GroupBy(student => student.Value.FullName.Contains(name));
        return returnedStudents;
    }

    public IEnumerable<KeyValuePair<int, Student>> GetPaginatedStudents(int page, int pageSize)
    {
        IEnumerable<KeyValuePair<int, Student>> returnedStudents = students.Skip((page - 1) * 10).Take(pageSize);
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
            modifiedStudent.Course = student.Course;

            return true;
        }

        return false;
    }

    public bool DeleteStudent(int studentId)
    {
        bool isDeleted = false;

        Student deletedStudent = this.GetStudentById(studentId);

        if (deletedStudent is not null)
            isDeleted = students.Remove(studentId);

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
        {
            foreach (var student in students)
            {
                this.CreateStudent(student.Value);
            }
        }
            
        return isAdded;
    }
}