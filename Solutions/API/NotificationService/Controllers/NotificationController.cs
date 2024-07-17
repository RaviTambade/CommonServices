using Microsoft.AspNetCore.Mvc;
using Transflower.NotifiactionService.Models;
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
    public async  Task<IActionResult> Notify(Message message)
    {   
        await _notificationSender.Send(message);
        return await Task.FromResult(Ok("Success"));
    }
}
