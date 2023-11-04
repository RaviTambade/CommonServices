using Transflower.MembershipRolesMgmt.Models;
namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;
public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAll();
    Task<Role?> GetById(int userRoleId);
    Task<List<string>> GetUsersId(string role);
    Task<List<string>> GetRolesByUserId(int userId);
    Task<bool> Insert(UserRole userRole);
    Task<bool> Update(UserRole userRole);
    Task<bool> Delete(int userRoleId);
}