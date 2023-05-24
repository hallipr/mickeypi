using Iot.Device.ServoMotor;
using System.Device.Pwm.Drivers;

namespace MickeyPi.Character;

public class SoftwareServo : IDisposable
{
    private readonly SoftwarePwmChannel _channel;
    private readonly ServoMotor _motor;
    private double _angle;
    private bool disposedValue;

    public SoftwareServo(int pinNumber, int frequency, double maximumAngle, int minimumPulseWidthMicroseconds, int maximumPulseWidthMicroseconds)
    {
        PinNumber = pinNumber;
        Frequency = frequency;
        MaximumAngle = maximumAngle;
        MinimumPulseWidthMicroseconds = minimumPulseWidthMicroseconds;
        MaximumPulseWidthMicroseconds = maximumPulseWidthMicroseconds;
        
        _channel = new SoftwarePwmChannel(pinNumber, frequency, usePrecisionTimer: true);
        _motor = new ServoMotor(_channel);
        _motor.Calibrate(maximumAngle, minimumPulseWidthMicroseconds, maximumPulseWidthMicroseconds);
    }

    public SoftwareServo(ServoSettings settings)
    : this(
        settings.Channel,
        settings.Frequency,
        settings.MaximumAngle,
        settings.MinimumPulseWidthMicroseconds,
        settings.MaximumPulseWidthMicroseconds
    )
    {
    }
    
    public int PinNumber { get; }

    public int Frequency { get; }

    public double MaximumAngle { get; }

    public int MinimumPulseWidthMicroseconds { get; }

    public int MaximumPulseWidthMicroseconds { get; }

    public double Angle
    {
        get => _angle;
        set
        {
            _motor.WriteAngle(value);
            _angle = value;
        }
    }

    public void Start()
    {
        _motor.Start();
    }

    public void Stop()
    {
        _motor.Stop();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _channel.Dispose();
                _motor.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
