
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

    public async Task<bool> Add(Address address)
    {
        return await _repository.Add(address);
    }

    public async Task<List<AddressInfo>> GetAddresses(int userId)
    {
        return await _repository.GetAddresses(userId);
    }

    public async Task<List<AddressInfo>> GetAddressesInformationFromId(string addressIdString)
    {
        return await _repository.GetAddressesInformationFromId(addressIdString);
    }

    public async Task<AddressInfo?> GetAddressInfo(int addressId)
    {
        return await _repository.GetAddressInfo(addressId);
    }

    public async Task<int> GetNearestAddressId(AddressIdRequest request)
    {
        return await _repository.GetNearestAddressId(request);
    }
}
