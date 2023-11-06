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
    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = await _svc.GetAllUsers();
        return users;
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<User> GetUser(int userId)
    {
        return await _svc.GetUser(userId);
    }

    [HttpGet("usersid/{role}")]
    public async Task<List<int>> GetUsersId(string role)
    {
        return await _svc.GetUsersId(role);
    }

    [HttpGet("roles/{userId}")]
    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        return await _svc.GetRolesByUserId(userId);
    }

    [HttpGet]
    [Route("contact/{contactNumber}")]
    public async Task<User> GetUserByContact(string contactNumber)
    {
        return await _svc.GetUserByContact(contactNumber);
    }

    [HttpGet]
    [Route("name/{ids}")]
    public async Task<List<UserDetails>> GetUsersDetail(string ids)
    {
        return await _svc.GetUsersDetails(ids);
    }

    [HttpGet]
    [Route("username/{contactNumber}")]
    public async Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber)
    {
        return await _svc.GetUserDetailsByContactNumber(contactNumber);
    }
 
    // POST http://localhost:/api/users
    [HttpPost]
    public async Task<bool> Add(User user)
    {
        bool status = await _svc.Add(user);
        return status;
    }

    // [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<bool> Update(int id, User user)
    {
        bool status = await _svc.Update(id, user);
        return status;
    }

    [HttpDelete]
    [Route("DeleteUser/{userId}")]
    public async Task<bool> Delete(int userId)
    {
        return await _svc.Delete(userId);
    }
}
