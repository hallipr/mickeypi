using Iot.Device.ServoMotor;
using System.Device.Pwm.Drivers;

using SoftwarePwmChannel pwmChannel = new(21, 50, usePrecisionTimer: true);
// Example of hardware PWM using chip 0 and channel 21 on a dev board.
ServoMotor servoMotor = new ServoMotor(pwmChannel);
servoMotor.Start();  // Enable control signal.

var stepSize = 100;
var pulseWidth = 1500; // 1.5ms; Approximately 90 degrees.
var min = 500;
var max = 2500;


Console.WriteLine($"{pulseWidth} us");
servoMotor.WritePulseWidth(pulseWidth);

while(true)
{
    var key = Console.ReadKey(true);
    while(Console.KeyAvailable)
    {
        Console.ReadKey(true);
    }

    if(key.Key == ConsoleKey.Escape)
    {
        break;
    }

    if(key.Key == ConsoleKey.UpArrow)
    {
        pulseWidth = Math.Min(pulseWidth + stepSize, max);
        Console.WriteLine($"{pulseWidth} us");
        servoMotor.WritePulseWidth(pulseWidth);
    }
    else if(key.Key == ConsoleKey.DownArrow)
    {
        pulseWidth = Math.Max(pulseWidth - stepSize, min);
        Console.WriteLine($"{pulseWidth} us");
        servoMotor.WritePulseWidth(pulseWidth);
    }
    else if(key.Key == ConsoleKey.LeftArrow)
    {
        stepSize -= 10;
        Console.WriteLine($"{stepSize} step");
    }
    else if(key.Key == ConsoleKey.RightArrow)
    {
        stepSize += 10;
        Console.WriteLine($"{stepSize} step");
    }
}

servoMotor.Stop(); // Disable control signal.