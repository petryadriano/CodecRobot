using CodecRobot.Console;

public class Program
{
    
    public static void Main()
    {
        string size = Console.ReadLine();
        string movs = Console.ReadLine();
        Console.Write(new Robot().execute(size, movs));
    }    
}
