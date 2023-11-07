using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Helpers;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private readonly ICredentialService _credentialService;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AuthController(
        IConfiguration configuration,
        ICredentialService credentialService,
        IRoleService roleService,
        IUserService userService
    )
    {
        _credentialService = credentialService;
        _roleService = roleService;
        _configuration = configuration;
        _userService = userService;
    }

    // [AllowAnonymous]
    [HttpPost]
    [Route("signin")]
    public async Task<AuthToken> SignIn([FromBody] Claim claim)
    {
        string strJwtToken = "";
        var status = await _credentialService.Authenticate(claim);
        if (status)
        {
            User user = await _userService.GetUserByContact(claim.ContactNumber);
            TokenHelper helper = new TokenHelper(_configuration, _roleService);
            strJwtToken = await helper.GenerateJwtToken(user);
        }
        return new AuthToken(strJwtToken);
    }

    [HttpPost("register")]
    public async Task<bool> Create(Credential credential)
    {
        return await _credentialService.Insert(credential);
    }

    [Authorize]
    [HttpPut("update/contactnumber")]
    public async Task<bool> Update(ContactNumberDetails details)
    {
        string currentContactNumber = (string)HttpContext.Items["contactNumber"];

        return await _credentialService.Update(currentContactNumber, details);
    }

    [Authorize]
    [HttpPut("update/password")]
    public async Task<bool> Update(PasswordDetails passwordDetails)
    {
        string? contactNumber = (string?)HttpContext.Items["contactNumber"];
        Console.WriteLine(contactNumber);
        return await _credentialService.Update(contactNumber, passwordDetails);
    }

    [HttpDelete("contactnumber/{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _credentialService.Delete(id);
    }
}
