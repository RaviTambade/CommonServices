using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.Threading.Tasks;

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
    public async Task<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest request)
    {
        var token = await _service.Authenticate(request);
        return token;
    }

    [HttpPost("register")]
    public async Task<bool> Register(Credential credential)
    {
        return await _service.Register(credential);
    }

    [HttpPut("updatecontactnumber")]
     public async Task<bool> UpdateContactNumber(ChangeContactNumber credential)
    {
        return await _service.UpdateContactNumber(credential);
    }

    [HttpPut("updatepassword")]
    public async Task<bool> UpdatePassword(ChangePassword credential)
    {
        return await _service.UpdatePassword(credential);
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}
