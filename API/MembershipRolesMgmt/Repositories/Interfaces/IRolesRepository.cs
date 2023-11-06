using Transflower.MembershipRolesMgmt.Models;
using Transflower.MembershipRolesMgmt.Models.Entities;
namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;
public interface IRoleRepository
{
    Task<List<UserRole>> GetAll();
    Task<List<Role>> GetRoles();
    Task<Role> GetById(int userRoleId);
   
    Task<bool> Insert(UserRole userRole);
    Task<bool> Update(UserRole userRole);
    Task<bool> Delete(int userRoleId);
}