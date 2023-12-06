
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUser(int userId);
    Task<List<User>> GetUsers(string roleName);
    Task<User> GetUserByContact(string contactNumber);
    Task<List<User>> GetUsersDetails(string ids);
    Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber);
    Task<bool> Update(int id, User user);
    Task<bool> Update(string contactNumber, PasswordDetails credential);
    Task<bool> Update(string contactNumber, ContactNumberDetails credential);
    Task<bool> Delete(int userId); 
    Task<bool> Add(User user);
    Task<bool> Authenticate(Claim claim);
}
