using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        BaseMenu baseMenu = new BaseMenu();

        baseMenu.ShowOptions();

        Console.Write("Select the necessary section: ");
        int option = int.Parse(Console.ReadLine());

        baseMenu.SelectOption(option);
    }
}