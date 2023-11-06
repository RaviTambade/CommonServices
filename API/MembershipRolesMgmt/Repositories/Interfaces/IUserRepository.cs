
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IUserRepository
{

    Task<List<User>> GetAllUsers();
    Task<User> GetUser(int userId);
     Task<List<string>> GetUsersByRole(string role);
    Task<List<string>> GetRolesByUserId(int userId);
    
    Task<User> GetUserByContact(string contactNumber);
    Task<List<UserDetails>> GetUsersDetails(string ids);
    Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber);
    Task<bool> Update(int id, User user);
    Task<bool> Delete(int userId); 
    Task<bool> Add(User user);
}
