using Transflower.NotifiactionService.Models;

namespace Transflower.NotifiactionService.Services.Interfaces;

public interface ISMSSender{
    void SendMessage(SMSMessage message);
}