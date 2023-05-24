using System.Text.Json.Serialization;

namespace MickeyPi.Api;

public class Servo
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("maximumAngle")]
    public double MaximumAngle { get; set; }

    [JsonPropertyName("minimumPulseWidthMicroseconds")]
    public int MinimumPulseWidthMicroseconds { get; set; }

    [JsonPropertyName("maximumPulseWidthMicroseconds")]
    public int MaximumPulseWidthMicroseconds { get; set; }

    [JsonPropertyName("angle")]
    public double Angle { get; set; }
}
