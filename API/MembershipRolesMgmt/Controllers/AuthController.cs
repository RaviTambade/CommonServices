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

    // [AllowAnonymous]
    [HttpPost]
    [Route("signin")]
    public async Task<AuthToken> SignIn([FromBody] Claim claim)
    {
        var token = await _service.Authenticate(claim);
        return token;
    }

    [HttpPost("register")]
    public async Task<bool> Create(Credential credential)
    {
        return await _service.Insert(credential);
    }

    // [Authorize]
    [HttpPut("update/contactnumber")]
    public async Task<bool> Update(ContactNumberDetails details)
    {
        string currentContactNumber = (string)HttpContext.Items["contactNumber"];

        return await _service.Update(currentContactNumber, details);
    }

    // [Authorize]
    [HttpPut("update/password")]
    public async Task<bool> Update(PasswordDetails passwordDetails)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];
        Console.WriteLine(contactNumber);
        return await _service.Update(contactNumber, passwordDetails);
    }

    [HttpDelete("contactnumber/{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}
