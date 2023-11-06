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

    //GET http://localhost:/api/users
    [Authorize]
    [HttpGet]
    public async Task<List<User>> GetAll()
    {
        List<User> peoples = await _svc.GetAll();
        return peoples;
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<User> GetbyId(int userId)
    {
        return await _svc.GetById(userId);
    }

    // GET http://localhost:/api/users/aadhar/76545656


    [HttpGet]
    [Route("aadhar/{aadharid}")]
    public async Task<User> GetDetails(string aadharid)
    {
        User people = await _svc.GetDetails(aadharid);
        return people;
    }

    // HTTPDELETE  http://localhost:/api/users/aadhar/76545656
    [HttpDelete]
    [Route("aadhar/{aadharid}")]
    public async Task<bool> Delete(string aadharid)
    {
        bool status = await _svc.DeleteByAadharId(aadharid);
        return status;
    }

    [HttpGet]
    [Route("contact/{contactNumber}")]
    public async Task<User> GetUserByContact(string contactNumber)
    {
        return await _svc.GetUserByContact(contactNumber);
    }

    [HttpGet]
    [Route("name/{userIdString}")]
    public async Task<List<UserFullName>> GetUsersDetail(string ids)
    {
        return await _svc.GetUserNameById(ids);
    }

    [HttpGet]
    [Route("username/{contactNumber}")]
    public async Task<UserFullName> GetUserName(string contactNumber)
    {
        return await _svc.GetUserName(contactNumber);
    }

    [HttpGet]
    [Route("userid/{contactNumber}")]
    public async Task<long> GetIdByContactNumber(string contactNumber)
    {
        return await _svc.GetIdByContactNumber(contactNumber);
    }


}
