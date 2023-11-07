

using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<Address>> GetAllAddresses(int userId);
    Task<List<Address>> GetAllAddresses(string addressIds);
    Task<bool> Insert(Address address);
}
