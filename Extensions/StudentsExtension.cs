using SchoolManagement.Models;

namespace SchoolManagement.Extensions;

public static class StudentsExtension
{
    public static IDictionary<int, Student> FindFirstOrDefaultCleverStudent(this IList<Student> students)
    {
        IDictionary<int, Student> cleverStudentOnCourse = new Dictionary<int, Student>();

        var studentsOnCourse = students.GroupBy(student => student.Course);

        foreach (var eachStudent in studentsOnCourse)
        {
            var cleverStudent = eachStudent.Aggregate((first, second) => first.Grade > second.Grade ? first : second);
            cleverStudentOnCourse.Add(eachStudent.Key, cleverStudent);
        }

        return cleverStudentOnCourse;
    }

    public static IDictionary<int, Student> FindFirstOrDefaultYoungestStudent(this IList<Student> students)
    {
        IDictionary <int, Student> youngestStudentOnCourse = new Dictionary<int, Student>();

        var studentsOnCourse = students.GroupBy(student => student.Course);

        foreach (var eachStudent in studentsOnCourse)
        {
            var youngestStudent = eachStudent.Aggregate((first, second) => first.Age < second.Grade ? first : second);
            youngestStudentOnCourse.Add(eachStudent.Key, youngestStudent);
        }

        return youngestStudentOnCourse;
    }

    public static IEnumerable<Student> Paginate (this IEnumerable<Student> students, int pageNumber, int pageSize) =>
        students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
}