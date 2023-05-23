namespace MickeyPi.Mickey;

public class Program
{
  public static async Task<int> Main(string[] args)
  {
    using var head = new MickeyHead();
    head.Start();

    while (true)
    {
      for (int i = 0; i <= 100; i++)
      {
        head.SetEyes(i);
        head.SetMouth(i);
        head.SetNose(i);
        await Task.Delay(20);
      }

      for (int i = 100; i >= 0; i--)
      {
        head.SetEyes(i);
        head.SetMouth(i);
        head.SetNose(i);
        await Task.Delay(20);
      }
    }
  }
}
