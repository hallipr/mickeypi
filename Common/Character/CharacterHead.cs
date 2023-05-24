namespace MickeyPi.Character;

public class CharacterHead : IDisposable
{
    private bool disposedValue;

    public CharacterHead(CharacterSettings settings)
    {
        Mouth = new SoftwareServo(settings.Mouth);
        Nose = new SoftwareServo(settings.Nose);
        Eyelids = new SoftwareServo(settings.Eyelids);
    }
    
    public SoftwareServo Mouth { get; }

    public SoftwareServo Nose { get; }

    public SoftwareServo Eyelids { get; }
    
    public void Start()
    {
        Mouth.Start();
        Nose.Start();
        Eyelids.Start();
    }

    public void Stop()
    {
        Mouth.Stop();
        Nose.Stop();
        Eyelids.Stop();
    }
 
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Mouth.Dispose();
                Nose.Dispose();
                Eyelids.Dispose();
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
