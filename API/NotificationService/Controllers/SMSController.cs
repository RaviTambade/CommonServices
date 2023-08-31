using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Transflower.NotifiactionService.Helpers;
using Transflower.NotifiactionService.Models;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Transflower.NotifiactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController : ControllerBase
{
    private readonly ITwilioRestClient _client;
    private readonly TwilioConfiguration _twilioConfiguration;

    public SmsController(
        ITwilioRestClient client,
        IOptions<TwilioConfiguration> twilioConfiguration
    )
    {
        _client = client;
        _twilioConfiguration = twilioConfiguration.Value;
    }

    [HttpPost]
    public  IActionResult SendMessage(SMSMessage model)
    {
        var message = MessageResource.Create(
            to: new PhoneNumber(model.To),
            from: new PhoneNumber(_twilioConfiguration.PhoneNumber),
            body: model.MessageText,
            client: _client
        );
        return Ok("Success");
    }
}
