using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<bool> Add(User user);
    Task<User> GetUserByContact(string contactNumber);
    Task<long> GetIdByContactNumber(string contactNumber);
    Task<List<UserNameWithId>> GetUserNameById(string userId);
    Task<bool> Update(int id, User user);
    Task<User> GetDetails(string aadharid);
    Task<User> GetById(int userId);
    Task<bool> DeleteByAadharId(string aadharid);
    Task<bool> DeletebyId(int userId);
}
