using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Services;

public class CredentialService : ICredentialService
{
    private readonly ICredentialRepository _credentialRepository;

    public CredentialService(ICredentialRepository credentialRepository)
    {
        _credentialRepository = credentialRepository;
    }

    public async Task<bool> Authenticate(Claim claim)
    {
        return await _credentialRepository.Authenticate(claim);
    }

    public async Task<bool> Insert(Credential credential)
    {
        return await _credentialRepository.Insert(credential);
    }

    public async Task<bool> Update(string contactNumber, ContactNumberDetails credential)
    {
        return await _credentialRepository.Update(contactNumber, credential);
    }

    public async Task<bool> Update(string contactNumber, PasswordDetails credential)
    {
        return await _credentialRepository.Update(contactNumber, credential);
    }

    public async Task<bool> Delete(int id)
    {
        return await _credentialRepository.Delete(id);
    }
}
