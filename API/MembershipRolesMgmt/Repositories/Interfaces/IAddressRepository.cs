

using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<AddressInfo>> GetAddresses(int userId);
    Task<List<AddressInfo>> GetAddressesInformationFromId(string addressIdString);
    Task<AddressInfo?> GetAddressInfo(int addressId);
    Task<bool> Add(Address address);
    Task<int> GetNearestAddressId(AddressIdRequest request);

}
