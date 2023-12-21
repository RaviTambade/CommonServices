// using System.Net.Mail;
using System.Net;
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
        var emailMessage = await CreateEmailMessage(message);

        await Send(emailMessage);
    }

    private async Task<MimeMessage> CreateEmailMessage(EmailMessage message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("TFLPORTAL", _emailConfig.From));
        emailMessage.To.AddRange(message.To.Select(x => new MailboxAddress(x, x)));
        emailMessage.Subject = message.Subject;

        Multipart multipart = new Multipart("mixed");

        TextPart body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

//sending file present on local server 
        // MimePart attachment = new MimePart("application", "octet-stream")
        // {
        //     Content = new MimeContent(System.IO.File.OpenRead("sm.txt")),
        //     ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        //     ContentTransferEncoding = ContentEncoding.Base64,
        //     FileName = "sm.txt"
        // };

//sending file which on remote serve

        // byte[] fileBytes = Array.Empty<byte>();
        // using (var client = new HttpClient())
        // {
        //     var response = await client.GetAsync("http://localhost:5263/abc.txt");
        //     if (response.IsSuccessStatusCode)
        //     {
        //         // Read the file content from the response
        //         fileBytes = await response.Content.ReadAsByteArrayAsync();
        //     }
        // }

        // var attachment = new MimePart("application", "octet-stream")
        // {
        //     Content = new MimeContent(new MemoryStream(fileBytes))
        //     ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
        //     ContentTransferEncoding = ContentEncoding.Base64,
        //     FileName = "abc.txt",
        // };

        // multipart.Add(attachment);

        multipart.Add(body);

        emailMessage.Body = multipart;

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
