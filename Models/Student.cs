namespace SchoolManagement.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string[] Subjects { get; set; }
}