namespace Transflower.NotifiactionService.Models;

public class SMSMessage
{
    public required string To { get; set; }
    public required string MessageText { get; set; }
}