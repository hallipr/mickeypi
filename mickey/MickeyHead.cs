namespace MickeyPi.Mickey;

public class MickeyHead : IDisposable
{
    private readonly SoftwareServo _mouth;
    private readonly SoftwareServo _nose;
    private readonly SoftwareServo _eyes;
    private bool disposedValue;

    public MickeyHead()
    {
        _mouth = new SoftwareServo(19);
        _nose = new SoftwareServo(20);
        _eyes = new SoftwareServo(21);

        _mouth.Calibrate(100, 1000, 2000);
        _nose.Calibrate(100, 1000, 2000);
        _eyes.Calibrate(100, 1000, 2000);
    }

    public void Start()
    {
        _mouth.Start();
        _nose.Start();
        _eyes.Start();
    }

    public void Stop()
    {
        _mouth.Stop();
        _nose.Stop();
        _eyes.Stop();
    }

    public void SetMouth(double angle)
    {
        _mouth.WriteAngle(angle);
    }

    public void SetNose(double angle)
    {
        _nose.WriteAngle(angle);
    }

    public void SetEyes(double angle)
    {
        _eyes.WriteAngle(angle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _mouth.Dispose();
                _nose.Dispose();
                _eyes.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
