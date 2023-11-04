
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IUserRepository
{

    Task<List<User>> GetAll();
    Task<bool> Add(User user);
    Task<User> GetUserByContact(string contactNumber);
    Task<long> GetIdByContactNumber(string contactNumber);
    Task<List<UserNameWithId>> GetUserNameById(string userIdString);
    Task<UserNameWithId> GetUserName(string contactNumber);
    Task<bool> Update(int id, User user);
    Task<User> GetDetails(string aadharid);
    Task<User> GetById(int userId);
    Task<bool> DeleteByAadharId(string aadharid);
    Task<bool> DeletebyId(int userId);

}
