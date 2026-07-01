using SchoolManagement.Exceptions;
using SchoolManagement.Menus;

namespace SchoolManagement;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            BaseMenu baseMenu = new BaseMenu();

            baseMenu.ShowOptions();

            Console.Write("Select the necessary section: ");
            int option = int.Parse(Console.ReadLine());

            await baseMenu.SelectOptionAsync(option);
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