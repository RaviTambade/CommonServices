using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _svc;

    public UsersController(IUserService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        List<User> users = await _svc.GetUsers();
        return users;
    }

    [HttpGet("roles/{role}")]
    public async Task<List<User>> GetUsersByRole(string role)
    {
        return await _svc.GetUsersByRole(role);
    }

    [HttpGet]
    [Route("ids/{userIds}")]
    public async Task<List<User>> GetUsersByUserIds(string userIds)
    {
        return await _svc.GetUsersByUserIds(userIds);
    }


    [HttpGet]
    [Route("details/ids/{userIds}")]
    public async Task<List<UserDetails>> GetUserDetailsByUserIds(string userIds)
    {
        return await _svc.GetUserDetailsByUserIds(userIds);
    }

    [Authorize]
    [HttpGet]
    [Route("{userId}")]
    public async Task<User> GetUser(int userId)
    {
        return await _svc.GetUser(userId);
    }

    [HttpGet]
    [Route("contact/{contactNumber}")]
    public async Task<User> GetUser(string contactNumber)
    {
        return await _svc.GetUser(contactNumber);
    }

    [HttpPost]
    [Route("add")]
    public async Task<bool> Add(User user)
    {
        bool status = await _svc.Add(user);
        return status;
    }

    // [Authorize]
    [HttpPut]
    [Route("{userId}")]
    public async Task<bool> Update(int userId, User user)
    {
        bool status = await _svc.Update(userId, user);
        return status;
    }

    [HttpDelete]
    [Route("{userId}")]
    public async Task<bool> Delete(int userId)
    {
        return await _svc.Delete(userId);
    }
}
