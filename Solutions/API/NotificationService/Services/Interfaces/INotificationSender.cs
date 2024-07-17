using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface INotificationSender
{
    Task Send(Message message);
}