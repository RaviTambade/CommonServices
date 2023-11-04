using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Entities;
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

    public async Task<Role?> GetById(int userRoleId)
    {
        return await _repository.GetById(userRoleId);
    }

    public async Task<List<string>> GetRolesByUserId(int userId)
    {
        return await _repository.GetRolesByUserId(userId);
    }

    public async Task<List<string>> GetUsersId(string role)
    {
        return await _repository.GetUsersId(role);
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