using Iot.Device.ServoMotor;
using System;
using System.Device.Pwm.Drivers;
using System.Threading;

Console.WriteLine("Hello PWM!");

using SoftwarePwmChannel pwmChannel = new(21, 50, usePrecisionTimer: true);
// Example of hardware PWM using chip 0 and channel 21 on a dev board.
ServoMotor servoMotor = new ServoMotor(pwmChannel);
servoMotor.Start();  // Enable control signal.

// Move position.  Pulse width argument is in microseconds.
Console.WriteLine("servoMotor.WritePulseWidth(1000)");
servoMotor.WritePulseWidth(1000); // 1ms; Approximately 0 degrees.
Thread.Sleep(3500);

Console.WriteLine("servoMotor.WritePulseWidth(1500)");
servoMotor.WritePulseWidth(1500); // 1.5ms; Approximately 90 degrees.
Thread.Sleep(3500);

Console.WriteLine("servoMotor.WritePulseWidth(2000)");
servoMotor.WritePulseWidth(2000); // 2ms; Approximately 180 degrees.
Thread.Sleep(3500);

servoMotor.Stop(); // Disable control signal.