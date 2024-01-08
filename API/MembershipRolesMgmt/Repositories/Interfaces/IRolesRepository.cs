using Transflower.MembershipRolesMgmt.Models;
using Transflower.MembershipRolesMgmt.Models.Entities;
namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;
public interface IRoleRepository
{
    Task<List<UserRole>> GetAll();
    Task<List<Role>> GetRoleDetails(string roleIds);
    Task<List<Role>> GetRoles(int userId,string lob);
    Task<List<Role>> GetRoles(int userId);
    Task<bool> Insert(UserRole userRole);
    Task<bool> Update(UserRole userRole);
    Task<bool> Delete(int userRoleId);
     
}