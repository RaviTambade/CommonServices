using PersonalInfoAPI.Models;

namespace PersonalInfoAPI.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<bool> Insert(Location theAddress);
    Task<bool> Update(Location theAddress);
}