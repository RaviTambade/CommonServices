
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Services;

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

    public async Task<bool> UpdateContactNumber(string contactNumber,ContactNumberDetails credential)
    {
        return await _credentialRepository.UpdateContactNumber(contactNumber,credential);
    }

    public async Task<bool> UpdatePassword( string contactNumber ,PasswordDetails credential)
    {
        return await _credentialRepository.UpdatePassword(contactNumber,credential);
    }

    public async Task<bool> Delete(int id)
    {
        return await _credentialRepository.Delete(id);
    }

    public async Task<AuthToken> Authenticate(Claim request)
    {
       return await _credentialRepository.Authenticate(request);
    }
}
