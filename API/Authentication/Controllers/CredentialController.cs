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


    [HttpPost("authenticate")]
    public  AuthenticateResponse Authenticate([FromBody] AuthenticateRequest request)
    {
        var token = _service.Authenticate(request);
        return token;
    }

    [HttpPost("register")]
    public bool Register(Credential credential)
    {
        return _service.Register(credential);
    }

    [HttpPut("updatecontactnumber")]
     public bool UpdateContactNumber(ChangeContactNumber credential)
    {
        return _service.UpdateContactNumber(credential);
    }

    [HttpPut("updatepassword")]
    public bool UpdatePassword(ChangePassword credential)
    {
        return _service.UpdatePassword(credential);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _service.Delete(id);
    }
}
