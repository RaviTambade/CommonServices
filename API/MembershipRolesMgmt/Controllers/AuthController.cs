using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MembershipRolesMgmt.Models;
using MembershipRolesMgmt.Services.Interfaces;
using MembershipRolesMgmt.Helpers;

namespace MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly ICredentialService _service;

    public CredentialController(ICredentialService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("signin")]
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

    // [Authorize]
    [HttpPut("update/contactnumber")]
    public async Task<bool> UpdateContactNumber(ContactNumberDetails credential)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];

        return await _service.UpdateContactNumber(contactNumber, credential);
    }


    // [Authorize]
    [HttpPut("update/password")]
    public async Task<bool> Update(PasswordDetails passwordDetails)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];
        Console.WriteLine(contactNumber);
        return await _service.UpdatePassword(contactNumber, passwordDetails);
    }

    [HttpDelete("contactnumber/{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}