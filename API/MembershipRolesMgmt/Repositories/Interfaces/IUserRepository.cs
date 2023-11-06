
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IUserRepository
{

    Task<List<User>> GetAllUsers();
    Task<bool> Add(User user);
    Task<User> GetUserByContact(string contactNumber);
    Task<bool> Update(int id, User user);
    Task<User> GetUser(int userId);
    Task<bool> Delete(int userId);
    Task<List<UserDetails>> GetUsersDetails(string ids);
    Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber);

}
