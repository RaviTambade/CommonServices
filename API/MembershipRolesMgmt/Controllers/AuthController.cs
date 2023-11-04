using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Entities;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly ICredentialService _service;

    public AuthController(ICredentialService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("signin")]
    public async Task<AuthToken> Authenticate([FromBody] Claim claim)
    {
        var token = await _service.Authenticate(claim);
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
        string contactNumber = (string)HttpContext.Items["contactNumber"];

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