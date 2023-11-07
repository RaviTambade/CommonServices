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
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AuthController(
        IConfiguration configuration,
        IRoleService roleService,
        IUserService userService
    )
    {     
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
        var status = await _userService.Authenticate(claim);
        if (status)
        {
            User user = await _userService.GetUserByContact(claim.ContactNumber);
            TokenHelper helper = new TokenHelper(_configuration, _roleService);
            strJwtToken = await helper.GenerateJwtToken(user);
        }
        return new AuthToken(strJwtToken);
    }

}
