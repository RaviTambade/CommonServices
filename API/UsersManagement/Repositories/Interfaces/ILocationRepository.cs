using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;

public interface ILocationRepository
{
    Task<bool> Insert(Location theAddress);
    Task<bool> Update(Location theAddress);
}