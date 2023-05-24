namespace MickeyPi.Character;

public class ServoSettings
{
    public int Channel { get; internal set; }
    public int Frequency { get; internal set; }
    public int MaximumAngle { get; internal set; }
    public int MinimumPulseWidthMicroseconds { get; internal set; }
    public int MaximumPulseWidthMicroseconds { get; internal set; }
}
