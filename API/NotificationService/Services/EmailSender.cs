using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Transflower.NotifiactionService.Helpers;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;

namespace Transflower.NotifiactionService.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    public EmailSender(IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendEmail(EmailMessage message)
    {
        var emailMessage = CreateEmailMessage(message);

        await Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(EmailMessage message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("TFLPORTAL", _emailConfig.From));
        emailMessage.To.AddRange(message.To.Select(x => new MailboxAddress("", x)));
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

        return emailMessage;
    }

    private async Task Send(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                await client.SendAsync(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
