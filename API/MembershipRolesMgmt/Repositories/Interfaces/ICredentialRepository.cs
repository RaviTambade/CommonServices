using MembershipRolesMgmt.Models;

namespace MembershipRolesMgmt.Repositories.Interfaces;

public interface ICredentialRepository
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<bool> Register(Credential credential);
    Task<bool> UpdatePassword(string contactNumber, PasswordDetails credential);
    Task<bool> UpdateContactNumber(string contactNumber, ContactNumberDetails credential);
    Task<bool> Delete(int id);
}
