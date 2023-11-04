using Microsoft.AspNetCore.Mvc;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using System.Threading.Tasks;
using AuthenticationAPI.Helpers;
namespace MembershipRolesMgmt.Controllers;


[ApiController]
[Route("/api/authentication")]
public class RolesController : ControllerBase
{
     private readonly IRoleService _service;

    public RolesController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<UserRole>> GetAll()
    {
        return await _service.GetAll();
    }

    [HttpGet("{userRoleId}")]
    public async Task<UserRole?> GetById(int userRoleId)
    {
        return await _service.GetById(userRoleId);
    }

    [HttpGet("roles/{userId}")]
    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        return await _service.GetRolesByUserId(userId);
    }

    [HttpPost]
    public async Task<bool> Insert(UserRole userRole)
    {
        return await _service.Insert(userRole);
    }

    [HttpGet("usersid/{role}")]
    public async Task<List<string>> GetUsersId(string role)
    {
        return await _service.GetUsersId(role);
    }

    [HttpPut]
    public async Task<bool> Update(UserRole userRole)
    {
        return await _service.Update(userRole);
    }

    [HttpDelete("{userRoleId}")]
    public async Task<bool> Delete(int userRoleId)
    {
        return await _service.Delete(userRoleId);
    }

   
}

