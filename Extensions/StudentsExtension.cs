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
}