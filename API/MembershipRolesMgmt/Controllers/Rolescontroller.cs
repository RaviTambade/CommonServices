using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/roles")]
public class RolesController : ControllerBase
{
     private readonly IRoleService _service;

    public RolesController(IRoleService service)
    {
        _service = service;
    }

     [HttpGet("userid")]
    public async Task<List<UserRole>> GetAll()
    {
        return await _service.GetAll();
    }


    [HttpGet("members")]
    public async Task<List<Role>> GetRoles()
    {
        return await _service.GetRoles();
    }


    [HttpGet("userrole")]
    public async Task<List<Role>> GetRolesOfUser(int userId)
    {
        return await _service.GetRolesOfUser(userId);
    }

    [HttpGet("{userRoleId}")]
    public async Task<Role?> GetById(int userRoleId)
    {
        return await _service.GetById(userRoleId);
    }

    [HttpPost]
    public async Task<bool> Create(UserRole userRole)
    {
        return await _service.Insert(userRole);
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

