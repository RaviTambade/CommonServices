using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Helpers;
using Microsoft.AspNetCore.Authorization;
using AuthorizeAttribute = Transflower.MembershipRolesMgmt.Helpers.AuthorizeAttribute;
using Microsoft.AspNetCore.Cors;

namespace Transflower.MembershipRolesMgmt.Controllers;

[Authorize]
[ApiController]
[Route("/api/auth")]
[EnableCors("AllowSpecificOrigin")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenHelper _tokenHelper;

    public AuthController(IUserService userService, TokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("signin")]
    public async Task<AuthToken> SignIn([FromBody] Claim claim)
    {
        string strJwtToken = string.Empty;
        
        var status = await _userService.Authenticate(claim);
        
        if (status)
        {
            User user = await _userService.GetUser(claim.ContactNumber);
            strJwtToken = await _tokenHelper.GenerateJwtToken(user, claim.Lob);
        }

        return new AuthToken(strJwtToken);
    }

    [HttpPut]
    [Route("updatepassword")]
    public async Task<bool> Update(PasswordDetails details)
    {
        Console.WriteLine("Old : " +details.OldPassword+" New : "+details.NewPassword );
        string currentContactNumber = HttpContext.Items["contactNumber"] as string ?? string.Empty;
        bool status = await _userService.Update(currentContactNumber, details);
        return status;
    }

    [HttpPut]
    [Route("updatecontactnumber")]
    public async Task<bool> Update(ContactNumberDetails credential)
    {
        string currentContactNumber = HttpContext.Items["contactNumber"] as string ?? string.Empty;
        bool status = await _userService.Update(currentContactNumber, credential);
        return status;
    }
}
