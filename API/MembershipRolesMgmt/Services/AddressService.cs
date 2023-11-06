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

    public async Task<List<AddressInfo>> GetAddressesofUser(int userId)
    {
        return await _repository.GetAddressesofUser(userId);
    }

    public async Task<List<AddressInfo>> GetAddressesInformation(string addressIdString)
    {
        return await _repository.GetAddressesInformation(addressIdString);
    }

    public async Task<AddressInfo?> GetAddress(int addressId)
    {
        return await _repository.GetAddress(addressId);
    }

    public async Task<int> GetNearestAddressId(AddressIdRequest request)
    {
        return await _repository.GetNearestAddressId(request);
    }

    public async Task<bool> Create(Address address)
    {
        return await _repository.Create(address);
    }
}
