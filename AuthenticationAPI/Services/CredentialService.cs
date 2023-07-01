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

    public bool Validate(Credential credential)
    {
        return _credentialRepository.Validate(credential);
    }

    public bool Register(Credential credential)
    {
        return _credentialRepository.Register(credential);
    }

    public bool UpdateContactNumber(ChangeContactNumber credential)
    {
        return _credentialRepository.UpdateContactNumber(credential);
    }

    public bool UpdatePassword(ChangePassword credential)
    {
        return _credentialRepository.UpdatePassword(credential);
    }

    public bool Delete(int id)
    {
        return _credentialRepository.Delete(id);
    }
}
