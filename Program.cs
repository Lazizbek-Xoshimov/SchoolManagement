using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        StudentMenu studentMenu = new StudentMenu();
        string outputSelection = string.Empty;

        do
        {
            studentMenu.ShowOptions();
            Console.Write("Select the necessary section: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        studentMenu.GetAllStudentsMenu();
                        break;
                    }
                case 2:
                    {
                        studentMenu.CreateStudentMenu();
                        break;
                    }
                case 3:
                    {
                        studentMenu.AddRandomStudentsMenu();
                        break;
                    }
                case 4:
                    {
                        studentMenu.ModifyStudentMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You have selected the wrong section.");
                        break;
                    }
            }

            Console.WriteLine("Do you want to exit the program?");
            Console.Write("(yes/no): ");
            outputSelection = Console.ReadLine();
        } while (outputSelection == "no");
    }
}