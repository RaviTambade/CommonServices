using AuthenticationAPI.Services.Interfaces;
using AuthenticationAPI.Repositories.Interfaces;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services;

public class CredentialService : ICredentialService
{
    private readonly ICredentialRepository _credentialRepository;

    public  CredentialService(ICredentialRepository credentialRepository)
    {
        _credentialRepository = credentialRepository;
    }


    public async Task<bool> Register(Credential credential)
    {
        return await _credentialRepository.Register(credential);
    }

    public async Task<bool> UpdateContactNumber(ChangeContactNumber credential)
    {
        return await _credentialRepository.UpdateContactNumber(credential);
    }

    public async Task<bool> UpdatePassword(ChangePassword credential)
    {
        return await _credentialRepository.UpdatePassword(credential);
    }

    public async Task<bool> Delete(int id)
    {
        return await _credentialRepository.Delete(id);
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
       return await _credentialRepository.Authenticate(request);
    }
}
