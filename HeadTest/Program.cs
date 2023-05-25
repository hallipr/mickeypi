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

        void AngleUp(SoftwareServo servo) => servo.Angle = Math.Min(servo.MaximumAngle, servo.Angle + stepSize);
        void AngleDown(SoftwareServo servo) => servo.Angle = Math.Max(0, servo.Angle - stepSize);

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
                    AngleDown(head.Mouth);
                    break;
                case ConsoleKey.Q:
                    AngleUp(head.Mouth);
                    break;
                case ConsoleKey.S:
                    AngleDown(head.Nose);
                    break;
                case ConsoleKey.W:
                    AngleUp(head.Nose);
                    break;
                case ConsoleKey.D:
                    AngleDown(head.Eyelids);
                    break;
                case ConsoleKey.E:
                    AngleUp(head.Eyelids);
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

            Console.WriteLine($"Mouth {head.Mouth.Angle}, Nose {head.Nose.Angle}, Eyelids {head.Eyelids.Angle}");
        }

        head.Stop(); // Disable control signal.
    }
}