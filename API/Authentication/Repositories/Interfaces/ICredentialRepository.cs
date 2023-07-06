using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repositories.Interfaces;

public interface ICredentialRepository{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<bool> Register(Credential credential);
    Task<bool> UpdatePassword(ChangePassword credential);
Task<bool> UpdateContactNumber(ChangeContactNumber credential);
   Task<bool> Delete(int id);

}