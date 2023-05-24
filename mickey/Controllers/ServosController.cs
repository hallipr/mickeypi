using Microsoft.AspNetCore.Mvc;
using MickeyPi.Character;
using MickeyPi.Api;
using System.Net;

namespace MickeyPi.Mickey.Controllers;

[ApiController]
[Route("[controller]")]
public class ServosController : ControllerBase
{
    private readonly ILogger<ServosController> _logger;
    private readonly CharacterHead _head;

    public ServosController(ILogger<ServosController> logger, CharacterHead head)
    {
        _logger = logger;
        _head = head;
    }

    [HttpGet]
    public IEnumerable<Servo> GetServos()
    {
        return new [] {
           GetServo("mouth"),
           GetServo("nose"),
           GetServo("eyelids"),
        };
    }

    [HttpGet("{id}")]
    public Servo GetServo(string id)
    {
        switch (id.ToLowerInvariant())
        {
            case "mouth":
                return ToApiServo(_head.Mouth, "mouth");
            case "nose":
                return ToApiServo(_head.Nose, "nose");
            case "eyelids":
                return ToApiServo(_head.Eyelids, "eyelids");
            default:
                throw new BadHttpRequestException("servo not found", (int)HttpStatusCode.NotFound);
        }
    }

    [HttpPut("{id}/position")]
    public void SetPosition(string id, double angle)
    {
        switch (id.ToLowerInvariant())
        {
            case "mouth":
                _head.Mouth.Angle = angle;
                break;
            case "nose":
                _head.Nose.Angle = angle;
                break;
            case "eyelids":
                _head.Eyelids.Angle = angle;
                break;
            default:
                throw new BadHttpRequestException("servo not found", (int)HttpStatusCode.NotFound);
        }

    }

    private static Servo ToApiServo(SoftwareServo servo, string id)
    {
        return new Servo {
            Id = id,
            MaximumAngle = servo.MaximumAngle,
            MinimumPulseWidthMicroseconds = servo.MinimumPulseWidthMicroseconds,
            MaximumPulseWidthMicroseconds = servo.MaximumPulseWidthMicroseconds,
            Angle = servo.Angle,
        };
    }
}
