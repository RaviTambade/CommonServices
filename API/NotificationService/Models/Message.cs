
namespace Transflower.NotifiactionService.Models;
public class Message
{
    public required List<string> ToEmail { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required string ToPhone { get; set; }
  
}