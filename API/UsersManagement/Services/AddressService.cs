using UsersManagement.Services.Interfaces;
using UsersManagement.Repositories.Interfaces;
using UsersManagement.Models;

namespace UsersManagement.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Add(Address address)
    {
        return await _repository.Add(address);
    }

    public async Task<List<Address>> GetAddresses(int userId)
    {
        return await _repository.GetAddresses(userId);
    }
}
