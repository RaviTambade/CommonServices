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

    [HttpGet]
    public async Task<List<Role>> GetRoles()
    {
        return await _service.GetRoles();
    }

    [HttpGet("lobs")]
    public async Task<List<string>> GetLOBs()
    {
        return await _service.GetLOBs();
    }

    [HttpGet("{userId}")]
    public async Task<List<Role>> GetRoles(int userId)
    {
        return await _service.GetRoles(userId);
    }

    [HttpGet("users/{userId}/lob/{lob}")]
    public async Task<List<Role>> GetRoles(int userId, string lob)
    {
        return await _service.GetRoles(userId, lob);
    }

    [HttpGet("ids/{roleIds}")]
    public async Task<List<Role>> GetRoles(string roleIds)
    {
        return await _service.GetRoles(roleIds);
    }

    [HttpGet("lob/{lob}")]
    public async Task<List<Role>> GetRolesByLob(string lob)
    {
        return await _service.GetRolesByLob(lob);
    }

     [HttpGet("getUserAndRoles/lob/{lob}")]
    public async Task<List<UserRoleDetails>> GetUserAndRolesByLob(string lob)
    {
        return await _service.GetUserAndRolesByLob(lob);
    }

    [HttpGet("getuserbylob/lob/{lob}")]
    public async Task<List<User>> UserDetailsByLob(string lob)
    {
        var lobObj = new LOB { Lob = lob };
        return await _service.UserDetailsByLob(lobObj);
    }

    [HttpGet("getuserbyroles/rolename/{roleName}/lob/{lob}")]
     public async Task<List<User>> UserDetailsByRole(string roleName, string lob)
     {
        var lobObj = new LOB { RoleName = roleName, Lob = lob };
        return await _service.UserDetailsByRole(lobObj);
     }

    [HttpPost("addrole")]
    public async Task<bool> Insert(Role role)
    {
        return await _service.Insert(role);
    }

    [HttpPut]
    public async Task<bool> Update(Role role)
    {
        return await _service.Update(role);
    }

    [HttpDelete("{roleId}")]
    public async Task<bool> DeleteRole(int roleId)
    {
        return await _service.DeleteRole(roleId);
    }

    [HttpPost("userroles")]
    public async Task<bool> Insert(UserRole userRole)
    {
        return await _service.Insert(userRole);
    }

    [HttpPut("userroles")]
    public async Task<bool> Update(UserRole userRole)
    {
        return await _service.Update(userRole);
    }

    [HttpDelete("userroles/{userRoleId}")]
    public async Task<bool> DeleteUserRole(int userRoleId)
    {
        return await _service.DeleteUserRole(userRoleId);
    }

    [HttpGet("userid/{userId}/roleId/{roleId}")]
    public async Task<bool> CheckUserRole(int userId, int roleId)
    {
        return await _service.CheckUserRole(userId, roleId);
    }

     [HttpDelete]
    [Route("remove/userroles/userid/{userId}/roleid/{roleId}")]
    public async Task<bool> RemoveUserRole(int userId,int roleId)
    {
        return await _service.DeleteRoleByUserId(userId,roleId);
    }
}
