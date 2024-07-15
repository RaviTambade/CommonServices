using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Entities;

namespace Transflower.MembershipRolesMgmt.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Role>> GetRoles()
    {
        return await _repository.GetRoles();
    }

    public async Task<List<Role>> GetRoles(string roleIds)
    {
        return await _repository.GetRoles(roleIds);
    }

    public async Task<List<Role>> GetRoles(int userId, string lob)
    {
        return await _repository.GetRoles(userId, lob);
    }

    public async Task<List<Role>> GetRoles(int userId)
    {
        return await _repository.GetRoles(userId);
    }

    public async Task<List<Role>> GetRolesByLob(string lob)
    {
        return await _repository.GetRolesByLob(lob);
    }

    public async Task<List<UserRoleDetails>> GetUserAndRolesByLob(string lob)
    {
        return await _repository.GetUserAndRolesByLob(lob);
    }

    public async Task<List<User>> UserDetailsByLob(LOB lob)
    {
        return await _repository.UserDetailsByLob(lob);
    }

    public async Task<List<User>> UserDetailsByRole(LOB lob)
     {
        return await _repository.UserDetailsByRole(lob);
     }

    public async Task<bool> Insert(Role role)
    {
        return await _repository.Insert(role);
    }

    public async Task<bool> Update(Role role)
    {
        return await _repository.Update(role);
    }

    public async Task<bool> DeleteRole(int roleId)
    {
        return await _repository.DeleteRole(roleId);
    }

    public async Task<bool> DeleteRoleByUserId(int userId,int roleId)
    {
        return await _repository.DeleteRoleByUserId(userId,roleId);
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        return await _repository.Insert(userRole);
    }

    public async Task<bool> Update(UserRole userRole)
    {
        return await _repository.Update(userRole);
    }

    public async Task<bool> DeleteUserRole(int userRoleId)
    {
        return await _repository.DeleteUserRole(userRoleId);
    }

    public async Task<bool> CheckUserRole(int userId, int roleId)
    {
        return await _repository.CheckUserRole(userId, roleId);
    }

    public async Task<List<string>> GetLOBs()
    {
        return await _repository.GetLOBs();

    }
}
