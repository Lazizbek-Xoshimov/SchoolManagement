using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Welcome to SchoolManagement");
        Console.ResetColor();
        Console.WriteLine("1. Student Management");
        Console.WriteLine("2. Teacher Management");
        Console.WriteLine("0. Exit");
        Console.Write("Select the necessary section: ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                {
                    StudentMenu studentMenu = new StudentMenu();
                    string outputSelection = string.Empty;

                    do
                    {
                        studentMenu.ShowOptions();
                        Console.Write("Select the necessary section: ");
                        int optionStudent = int.Parse(Console.ReadLine());

                        switch (optionStudent)
                        {
                            case 1:
                                studentMenu.AddRandomStudentsMenu();
                                break;
                            case 2:
                                studentMenu.CreateStudentMenu();
                                break;
                            case 3:
                                studentMenu.GetAllStudentsMenu();
                                break;
                            case 4:
                                studentMenu.GetStudentsByIdMenu();
                                break;
                            case 5:
                                studentMenu.ModifyStudentMenu();
                                break;
                            case 6:
                                studentMenu.DeleteStudentMenu();
                                break;
                            case 7:
                                studentMenu.GetStudentsByNameMenu();
                                break;
                            default:
                                Console.WriteLine("You have selected the wrong section.");
                                break;
                        }

                        Console.WriteLine("Do you want to exit the program?");
                        Console.Write("(yes/no): ");
                        outputSelection = Console.ReadLine();
                    } while (outputSelection == "no");

                    break;
                }
            case 2:
                {
                    TeacherMenu teacherMenu = new TeacherMenu();
                    string outputSelection = string.Empty;

                    do
                    {
                        teacherMenu.ShowOptions();
                        Console.Write("Select the necessary section: ");
                        int optionStudent = int.Parse(Console.ReadLine());

                        switch (optionStudent)
                        {
                            case 1:
                                teacherMenu.AddRandomTeachersMenu();
                                break;
                            case 2:
                                teacherMenu.CreateTeacherMenu();
                                break;
                            case 3:
                                teacherMenu.GetTeacherByIdMenu();
                                break;
                            case 4:
                                teacherMenu.GetAllTeachersMenu();
                                break;
                            case 5:
                                teacherMenu.ModifyTeacherMenu();
                                break;
                            case 6:
                                teacherMenu.DeleteTeacherMenu();
                                break;
                            default:
                                Console.WriteLine("You have selected the wrong section.");
                                break;
                        }

                        Console.WriteLine("Do you want to exit the program?");
                        Console.Write("(yes/no): ");
                        outputSelection = Console.ReadLine();
                    } while (outputSelection == "no");

                    break;   
                }
            case 0:
                break;
            default:
                Console.WriteLine("You have selected the wrong section.");
                break;
        }
    }
}