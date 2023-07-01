using AuthenticationAPI.Services.Interfaces;
using AuthenticationAPI.Repositories.Interfaces;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services;

public class CredentialService : ICredentialService
{
    private readonly ICredentialRepository _credentialRepository;

    public CredentialService(ICredentialRepository credentialRepository)
    {
        _credentialRepository = credentialRepository;
    }

    public bool Delete(int id)
    {
        return _credentialRepository.Delete(id);
    }

    public bool Register(Credential credential)
    {
        return _credentialRepository.Register(credential);
    }

 

    public bool UpdatePassword(ChangedCredential credential)
    {
        return _credentialRepository.UpdatePassword(credential);
    }

    public bool Validate(Credential credential)
    {
        return _credentialRepository.Validate(credential);
    }
}
