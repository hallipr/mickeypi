namespace MickeyPi.Mickey;

public class Program
{
    public static void Main(string[] args)
    {
        using var head = new MickeyHead();
        head.Start();

        head.SetEyes(100);
        head.SetMouth(100);
        head.SetNose(0);

        while(true)
        {
            var key = Console.ReadKey(true);
            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            switch(key.KeyChar)
            {
                case 'a':
                    head.SetMouth(0);
                    break;
                case 'q':
                    head.SetMouth(100);
                    break;
                case 's':
                    head.SetNose(0);
                    break;
                case 'w':
                    head.SetNose(100);
                    break;
                case 'd':
                    head.SetEyes(0);
                    break;
                case 'e':
                    head.SetEyes(100);
                    break;
                default:
                    break;
            }

            if(key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        head.Stop();
    }
}
