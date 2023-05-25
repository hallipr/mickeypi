using Iot.Device.ServoMotor;
using MickeyPi.Character;

public class Program
{
    public static void Main(string[] args)
    {
        using var head = new CharacterHead(new CharacterSettings
        {
            Mouth = {
                Channel = 19,
                Frequency = 50,
                MaximumAngle = 100,
                MinimumPulseWidthMicroseconds = 1200,
                MaximumPulseWidthMicroseconds = 1950
            },
            Nose = {
                Channel = 20,
                Frequency = 50,
                MaximumAngle = 100,
                MinimumPulseWidthMicroseconds = 1200,
                MaximumPulseWidthMicroseconds = 1950
            },
            Eyelids = {
                Channel = 21,
                Frequency = 50,
                MaximumAngle = 100,
                MinimumPulseWidthMicroseconds = 1200,
                MaximumPulseWidthMicroseconds = 1800
            },
        });

        head.Start();

        var stepSize = 100;

        while (true)
        {
            var key = Console.ReadKey(true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }

            switch(key.Key)
            {
                case ConsoleKey.A:
                    head.Mouth.Angle -= stepSize;
                    Console.WriteLine($"Mouth {head.Mouth.Angle}");
                    break;
                case ConsoleKey.Q:
                    head.Mouth.Angle += stepSize;
                    Console.WriteLine($"Mouth {head.Mouth.Angle}");
                    break;
                case ConsoleKey.S:
                    head.Nose.Angle -= stepSize;
                    Console.WriteLine($"Nose {head.Nose.Angle}");
                    break;
                case ConsoleKey.W:
                    head.Nose.Angle += stepSize;
                    Console.WriteLine($"Nose {head.Nose.Angle}");
                    break;
                case ConsoleKey.D:
                    head.Eyelids.Angle -= stepSize;
                    Console.WriteLine($"Eyelids {head.Eyelids.Angle}");
                    break;
                case ConsoleKey.E:
                    head.Eyelids.Angle += stepSize;
                    Console.WriteLine($"Eyelids {head.Eyelids.Angle}");
                    break;
                case ConsoleKey.UpArrow:
                    stepSize = Math.Min(100, stepSize + 10);
                    Console.WriteLine($"{stepSize} step");
                    break;
                case ConsoleKey.DownArrow:
                    stepSize = Math.Max(0, stepSize - 10);
                    Console.WriteLine($"{stepSize} step");
                    break;
                default:
                    break;
            }
        }

        head.Stop(); // Disable control signal.
    }
}