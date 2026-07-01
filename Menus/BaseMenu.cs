namespace SchoolManagement.Menus;

public class BaseMenu
{
    public void ShowOptions()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Welcome to SchoolManagement");
        Console.ResetColor();
        Console.WriteLine("1. Student Management");
        Console.WriteLine("2. Teacher Management");
        Console.WriteLine("0. Exit");
    }

    public async Task SelectOptionAsync(int option)
    {
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

                    await studentMenu.SelectOptionAsync(optionStudent);

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
                    int optionTeacher = int.Parse(Console.ReadLine());

                    await teacherMenu.SelectOptionAsync(optionTeacher);

                    Console.WriteLine("Do you want to exit the program?");
                    Console.Write("(yes/no): ");
                    outputSelection = Console.ReadLine();
                } while (outputSelection == "no");

                break;   
            }
            case 0: break;
            default: Console.WriteLine("You have selected the wrong section."); break;
        }
    }
}