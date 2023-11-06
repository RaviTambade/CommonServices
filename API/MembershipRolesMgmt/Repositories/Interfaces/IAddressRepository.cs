

using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<AddressInfo>> GetAddressesofUser(int userId);
    Task<List<AddressInfo>> GetAddressesInformation(string addressIds);
    Task<AddressInfo?> GetAddress(int addressId);
    Task<int> GetNearestAddressId(AddressIdRequest request);
    Task<bool> Create(Address address);
}
