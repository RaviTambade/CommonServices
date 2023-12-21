using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface ISMSSender{
    Task SendMessage(SMSMessage message);
}