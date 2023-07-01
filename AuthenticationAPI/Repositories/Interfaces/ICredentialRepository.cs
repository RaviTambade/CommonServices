using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repositories.Interfaces;

public interface ICredentialRepository{
    bool Validate(Credential credential); 
    bool Register(Credential credential);
    bool UpdatePassword(ChangePassword credential);
    bool UpdateContactNumber(ChangeContactNumber credential);
    bool Delete(int id);
}