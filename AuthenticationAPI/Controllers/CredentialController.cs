using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;

namespace AuthenticationAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CredentialController : ControllerBase
{
    private readonly ICredentialService _service;

    public CredentialController(ICredentialService service)
    {
        _service = service;
    }

    [HttpPost("validate")]
    public bool Validate(Credential credential)
    {
        return _service.Validate(credential);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }

    [HttpPost("register")]
    public bool Register(Credential credential)
    {
        return _service.Register(credential);
    }

    [HttpPut("updatepassword")]
    public bool UpdatePassword(ChangedCredential credential)
    {
        return _service.UpdatePassword(credential);
    }
}
