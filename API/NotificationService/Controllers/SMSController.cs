using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Transflower.NotifiactionService.Helpers;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;


namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController : ControllerBase
{
    private readonly ISMSSender _smsSender;

    public SmsController(
        ISMSSender smsSender
    )
    {
        _smsSender = smsSender;
    }

    [HttpPost]
    public IActionResult SendMessage(SMSMessage message)
    {
        _smsSender.SendMessage(message);
        return Ok("Success");
    }
}
