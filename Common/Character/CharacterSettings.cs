namespace MickeyPi.Character;

public class CharacterSettings
{
    public ServoSettings Mouth { get; set; } = new();
    public ServoSettings Nose { get; set; } = new();
    public ServoSettings Eyelids { get; set; } = new();
}
