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

    public void Send(Message message)
    {
        SendSms(message);
        SendEmail(message);
    }


    private void SendSms(Message message)
    {
        var smsMessage = new SMSMessage() { To = message.ToPhone, MessageText = message.Body };
        _smsSender.SendMessage(smsMessage);
    }

    private void SendEmail(Message message)
    {
        var emailMessage = new EmailMessage(
            to: message.ToEmail,
            subject: message.Subject,
            body: message.Body
        );

        _mailsender.SendEmail(emailMessage);
    }
}
