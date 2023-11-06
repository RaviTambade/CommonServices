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


     public async Task<List<Role>> GetRoles()
    {
        return await _repository.GetRoles();
    }

    public async Task<Role?> GetById(int userRoleId)
    {
        return await _repository.GetById(userRoleId);
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