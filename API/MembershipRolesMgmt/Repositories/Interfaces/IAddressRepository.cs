

using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<AddressInfo>> GetAllAddresses(int userId);
    Task<List<AddressInfo>> GetAllAddresse(string addressIds);
   
    Task<Address> GetNearestAddress(AddressIdRequest request);
    Task<bool> Insert(Address address);
}
