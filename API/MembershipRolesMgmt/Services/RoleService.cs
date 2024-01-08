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

    public async Task<List<UserRole>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<List<Role>> GetRoleDetails(string roleIds)
    {
        return await _repository.GetRoleDetails(roleIds);
    }

    public async Task<List<Role>> GetRoles(int userId,string lob)
    {
        return await _repository.GetRoles(userId,lob);
    }

    public async Task<List<Role>> GetRoles(int userId)
    {
        return await _repository.GetRoles(userId);
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        return await _repository.Insert(userRole);
    }

    public async Task<bool> Update(UserRole userRole)
    {
        return await _repository.Update(userRole);
    }

    public async Task<bool> Delete(int userRoleId)
    {
        return await _repository.Delete(userRoleId);
    }
}
