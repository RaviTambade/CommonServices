using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface IEmailSender
{
    Task SendEmail(EmailMessage message);
}