using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        string outputSelection = string.Empty;

        do
        {
            StudentMenu studentMenu = new StudentMenu();

            Console.Write("Select the necessary section: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1 :
                    {
                        studentMenu.GetAllStudentsMenu();
                        break;
                    }
                case 2:
                    {
                        studentMenu.CreateStudentMenu();
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