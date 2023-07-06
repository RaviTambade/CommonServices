using UsersManagement.Services.Interfaces;
using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;
namespace UsersManagement.Services;

public class UserService:IUserService{

    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo){
        _repo=repo;
    }


    public async Task<List<User>> GetAllUsers() => await _repo.GetAllUsers();

    public async Task<bool> AddUser(User user)=> await _repo.AddUser(user);

    public async Task<bool> UpdateUser(int id,User user)=> await _repo.UpdateUser(id,user);

    public async Task<User> GetDetails(string adharid) => await _repo.GetDetails(adharid);

   public async Task<bool> DeleteUser(string aaddharid)=> await _repo.DeleteUser(aaddharid);
    public async Task<User> GetUser(int userId)=>await _repo.GetUser(userId);
   public async Task<bool> DeleteUserbyId(int userId)=> await _repo.DeleteUserbyId(userId);

    

}