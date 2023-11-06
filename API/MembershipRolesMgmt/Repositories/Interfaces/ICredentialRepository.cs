
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface ICredentialRepository
{
    Task<AuthToken> Authenticate(Claim claim);
    Task<bool> Insert(Credential credential);
    Task<bool> Update(string contactNumber, PasswordDetails credential);
    Task<bool> Update(string contactNumber, ContactNumberDetails credential);
    Task<bool> Delete(int id);
}
