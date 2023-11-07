using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Address>> GetAllAddresses(int userId)
    {
        return await _repository.GetAllAddresses(userId);
    }

    public async Task<List<Address>> GetAllAddresses(string addressIds)
    {
        return await _repository.GetAllAddresses(addressIds);
    }

   
    public async Task<bool> Insert(Address address)
    {
        return await _repository.Insert(address);
    }
}
