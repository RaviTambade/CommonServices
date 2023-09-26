using UsersManagement.Services.Interfaces;
using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;

namespace UsersManagement.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<User>> GetAll() => await _repo.GetAll();

    public async Task<bool> Add(User user) => await _repo.Add(user);

    public async Task<bool> Update(int id, User user) => await _repo.Update(id, user);

    public async Task<User> GetDetails(string aadharid) => await _repo.GetDetails(aadharid);

    public async Task<bool> DeleteByAadharId(string aadharid) =>
        await _repo.DeleteByAadharId(aadharid);

    public async Task<User> GetById(int userId) => await _repo.GetById(userId);

    public async Task<bool> DeletebyId(int userId) => await _repo.DeletebyId(userId);

    public async Task<List<UserNameWithId>> GetUserNameById(string userId) =>
        await _repo.GetUserNameById(userId);
    public async Task<UserNameWithId> GetUserName(string contactNumber) =>
        await _repo.GetUserName(contactNumber);

    public async Task<User> GetUserByContact(string contactNumber) =>
        await _repo.GetUserByContact(contactNumber);

    public async Task<long> GetIdByContactNumber(string contactNumber) =>
        await _repo.GetIdByContactNumber(contactNumber);
}
