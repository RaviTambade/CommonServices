using Microsoft.Extensions.Options;
using Transflower.NotifiactionService.Helpers;
using Transflower.NotifiactionService.Models;
using Transflower.NotifiactionService.Services.Interfaces;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SystemHttpClient = System.Net.Http.HttpClient;

namespace Transflower.NotifiactionService.Services;

public class TwilioClient : ITwilioRestClient, ISMSSender
{
    private readonly ITwilioRestClient _client;

    private readonly TwilioConfiguration _twilioConfiguration;

    public TwilioClient(IOptions<TwilioConfiguration> twilioConfiguration, SystemHttpClient client)
    {
        _twilioConfiguration = twilioConfiguration.Value;

        _client = new TwilioRestClient(
            _twilioConfiguration.AccountSid,
            _twilioConfiguration.AuthToken,
            httpClient: new SystemNetHttpClient(client)
        );
    }

    public Response Request(Request request) => _client.Request(request);

    public Task<Response> RequestAsync(Request request) => _client.RequestAsync(request);

    public void SendMessage(SMSMessage message)
    {
        MessageResource.Create(
            to: new PhoneNumber(message.To),
            from: new PhoneNumber(_twilioConfiguration.PhoneNumber),
            body: message.MessageText,
            client: _client
        );
    }

    public string AccountSid => _client.AccountSid;
    public string Region => _client.Region;
    public Twilio.Http.HttpClient HttpClient => _client.HttpClient;
}
