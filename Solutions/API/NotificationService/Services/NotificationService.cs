using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;

namespace Transflower.NotifiactionService.Services;

public class NotifiactionSender : INotificationSender
{
    private readonly IEmailSender _mailsender;
    private readonly ISMSSender _smsSender;

    public NotifiactionSender(IEmailSender mailsender, ISMSSender smsSender)
    {
        _mailsender = mailsender;
        _smsSender = smsSender;
    }

    public async Task Send(Message message)
    {
       await Task.WhenAll(SendSms(message),SendEmail(message));
    }

    private async Task SendSms(Message message)
    {
        var smsMessage = new SMSMessage() { To = message.ToPhone, MessageText = message.Body };
        await _smsSender.SendMessage(smsMessage);
    }

    private async Task SendEmail(Message message)
    {
        var emailMessage = new EmailMessage(
            to: message.ToEmail,
            subject: message.Subject,
            body: message.Body
        );

        await _mailsender.SendEmail(emailMessage);
    }
}
