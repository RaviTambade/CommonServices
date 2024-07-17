using Microsoft.AspNetCore.Mvc;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;

namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("notification/email")]
public class EMailController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EMailController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(EmailMessage message)
    {
        await _emailSender.SendEmail(message);
        return await Task.FromResult(Ok("Email Sent Sucessfully"));
    }
}
