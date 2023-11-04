using Microsoft.AspNetCore.Mvc;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services;
using Transflower.NotifiactionService.Services.Interfaces;


namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationSender _notificationSender;

    public NotificationController(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    [HttpPost]
    public IActionResult Notify(Message message)
    {   
        _notificationSender.Send(message);
        return Ok("Success");
    }
}
