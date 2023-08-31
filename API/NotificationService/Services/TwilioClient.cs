using Microsoft.Extensions.Options;
using Transflower.NotifiactionService.Helpers;
using Twilio.Clients;
using Twilio.Http;
using SystemHttpClient = System.Net.Http.HttpClient;

namespace Transflower.NotifiactionService.Services;

public class TwilioClient : ITwilioRestClient
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

    public string AccountSid => _client.AccountSid;
    public string Region => _client.Region;
    public Twilio.Http.HttpClient HttpClient => _client.HttpClient;
    
}
