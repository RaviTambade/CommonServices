using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<User>> GetAllUsers() => await _repo.GetAllUsers();
    public async Task<User> GetUser(int userId) =>await _repo.GetUser(userId);
    public async Task<User> GetUserByContact(string contactNumber) => await _repo.GetUserByContact(contactNumber);
    public async Task<List<UserDetails>> GetUsersDetails(string ids)=> await _repo.GetUsersDetails(ids);
    public async Task<UserDetails> GetUserDetailsByContactNumber(string contactNumber)=> await _repo.GetUserDetailsByContactNumber(contactNumber);
    public async Task<List<int>> GetUsersId(string role)=> await _repo.GetUsersId(role);
    public async Task<List<string>> GetRolesByUserId(int userId)=> await _repo.GetRolesByUserId(userId); 
    public async Task<bool> Add(User user) => await _repo.Add(user);
    public async Task<bool> Update(int id, User user) => await _repo.Update(id, user);
    public async Task<bool> Delete(int userId)=>await _repo.Delete(userId);

      
}
