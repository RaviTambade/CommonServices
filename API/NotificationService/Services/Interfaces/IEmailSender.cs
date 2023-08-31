using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface IEmailSender
{
    void SendEmail(EmailMessage message);
}