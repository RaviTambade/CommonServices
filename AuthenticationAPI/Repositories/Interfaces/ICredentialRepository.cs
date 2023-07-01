using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repositories.Interfaces;

public interface ICredentialRepository{
    bool Validate(Credential credential); 
    bool Register(Credential credential);
    bool UpdatePassword(ChangedCredential credential);
    bool Delete(int id);
}