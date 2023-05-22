using Iot.Device.ServoMotor;
using System.Device.Pwm.Drivers;

namespace MickeyPi.Mickey;

public class SoftwareServo : IDisposable
{
    private readonly SoftwarePwmChannel _channel;
    private readonly ServoMotor _motor;
    private bool disposedValue;

    public SoftwareServo(int channel, int frequency = 50)
    {
        _channel = new SoftwarePwmChannel(channel, frequency, usePrecisionTimer: true);
        _motor = new ServoMotor(_channel);
    }

    public void Start()
    {
        _motor.Start();
    }

    public void Stop()
    {
        _motor.Stop();
    }

    public void Calibrate(double maximumAngle, double minimumPulseWidthMicroseconds, double maximumPulseWidthMicroseconds)
    {
        _motor.Calibrate(maximumAngle, minimumPulseWidthMicroseconds, maximumPulseWidthMicroseconds);
    }
    
    public void WritePulseWidth(int microseconds)
    {
        _motor.WritePulseWidth(microseconds);
    }

    public void WriteAngle(double angle)
    {
        _motor.WriteAngle(angle);
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
