namespace MickeyPi.Mickey;

public class Program
{
    public static void Main(string[] args)
    {
        using var head = new MickeyHead();
        head.Start();

        head.SetEyes(0);
        head.SetEyes(100);

        head.Stop();
    }
}
