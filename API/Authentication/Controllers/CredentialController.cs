using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.Threading.Tasks;
using AuthenticationAPI.Helpers;

namespace AuthenticationAPI.Controllers;

[ApiController]
[Route("/api/authentication")]
public class CredentialController : ControllerBase
{
    private readonly ICredentialService _service;

    public CredentialController(ICredentialService service)
    {
        _service = service;
    }

    //http://localhost:5664/api/authentication/login
    //http://localhost:56455/authentication/signin
    //http:localhost:56455/membership/signin
    [HttpPost]
    [Route("signin")]
    public async Task<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest request)
    {
        var token = await _service.Authenticate(request);
        return token;
    }

    //http:localhost:56455/authentication/register
    [HttpPost("register")]
    public async Task<bool> Register(Credential credential)
    {
        return await _service.Register(credential);
    }

    //http:localhost:56455/authentication/update/contactnumber
    [Authorize]
    [HttpPut("update/contactnumber")]
    public async Task<bool> UpdateContactNumber(ContactNumberDetails credential)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];

        return await _service.UpdateContactNumber(contactNumber, credential);
    }

    //http:localhost:56455/authentication/update/password
    [Authorize]
    [HttpPut("update/password")]
    public async Task<bool> Update(PasswordDetails passwordDetails)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];
        return await _service.UpdatePassword(contactNumber, passwordDetails);
    }

    [HttpDelete("contactnumber/{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}

