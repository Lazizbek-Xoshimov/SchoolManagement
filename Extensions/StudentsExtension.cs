using SchoolManagement.Models;

namespace SchoolManagement.Extensions;

public static class StudentsExtension
{
    public static IDictionary<int, Student> FindFirstOrDefaultCleverStudent(this IDictionary<int, Student> students)
    {
        IDictionary<int, Student> cleverStudentOnCourse = new Dictionary<int, Student>();

        var studentsOnCourse = students.GroupBy(student => student.Value.Course);

        foreach (var eachStudent in studentsOnCourse)
        {
            var cleverStudent = eachStudent.Aggregate((first, second) => first.Value.Grade > second.Value.Grade ? first : second);
            cleverStudentOnCourse.Add(eachStudent.Key, cleverStudent.Value);
        }

        return cleverStudentOnCourse;
    }

    public static IDictionary<int, Student> FindFirstOrDefaultYoungestStudent(this IDictionary<int, Student> students)
    {
        IDictionary <int, Student> youngestStudentOnCourse = new Dictionary<int, Student>();

        var studentsOnCourse = students.GroupBy(student => student.Value.Course);

        foreach (var eachStudent in studentsOnCourse)
        {
            var youngestStudent = eachStudent.Aggregate((first, second) => first.Value.Age < second.Value.Grade ? first : second);
            youngestStudentOnCourse.Add(eachStudent.Key, youngestStudent.Value);
        }

        return youngestStudentOnCourse;
    }

    public static IEnumerable<KeyValuePair<int, Student>> Paginate (this IEnumerable<KeyValuePair<int, Student>> students, int pageNumber, int pageSize) =>
        students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
}