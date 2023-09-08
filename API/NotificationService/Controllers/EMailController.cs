using Microsoft.AspNetCore.Mvc;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;

namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class EMailController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EMailController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost]
    public IActionResult SendMessage(EmailMessage message)
    {
        _emailSender.SendEmail(message);
        return Ok("EMail sent successfully");
    }
}
