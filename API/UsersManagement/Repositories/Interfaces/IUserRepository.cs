using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;
public interface IUserRepository
{
   Task<List<User>> GetAllUsers();
   Task<bool> AddUser(User user);

   Task<bool> UpdateUser(int id,User user);

   Task<User> GetDetails(string addharid);
   Task<User> GetUser(int userId);

   Task<bool> DeleteUser(string addharid);
   Task<bool> DeleteUserbyId(int userId);

}