using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<Address>> GetAddresses(int userId);

    Task<bool> Add(Address address);
}
