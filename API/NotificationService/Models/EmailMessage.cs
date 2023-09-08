namespace Transflower.NotifiactionService.Models;

public class EmailMessage
{
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }


    public EmailMessage(List<string> to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }
}
