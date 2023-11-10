using UsersManagement.Models;

namespace UsersManagement.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<AddressInfo>> GetAddresses(int userId);
    Task<List<AddressInfo>> GetAddressesInformationFromId(string addressIdString);
    Task<AddressInfo?> GetAddressInfo(int addressId);
    Task<bool> Add(Address address);
    Task<int> GetNearestAddressId(AddressIdRequest request);

}
