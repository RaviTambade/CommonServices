using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface INotificationSender
{
    void Send(Message message);
}