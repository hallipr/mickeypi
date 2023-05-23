namespace MickeyPi.Mickey;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        using var head = new MickeyHead();
        head.Start();

        head.SetEyes(0);
        head.SetMouth(0);
        head.SetNose(100);

        await Task.Delay(1000);

        head.SetEyes(100);
        head.SetMouth(100);
        head.SetNose(0);

        while(true)
        {
           await Task.Delay(2000);
           head.SetEyes(Random.Shared.Next(0, 100));
           head.SetMouth(Random.Shared.Next(0, 100));
           head.SetNose(Random.Shared.Next(0, 100));
        }
    }
}
