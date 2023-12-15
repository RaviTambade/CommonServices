using Microsoft.AspNetCore.Mvc;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;

namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController : ControllerBase
{
    private readonly ISMSSender _smsSender;

    public SmsController(ISMSSender smsSender)
    {
        _smsSender = smsSender;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(SMSMessage message)
    {
        await _smsSender.SendMessage(message);
        return await Task.FromResult(Ok("Success"));
    }
}
