using SchoolManagement.Exceptions;
using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            BaseMenu baseMenu = new BaseMenu();

            baseMenu.ShowOptions();

            Console.Write("Select the necessary section: ");
            int option = int.Parse(Console.ReadLine());

            baseMenu.SelectOption(option);
        }
        catch (ValidationException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (NotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}