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

    public async Task<Address> GetAddress(int addressId)
    {
        return await _repository.GetAddress(addressId);
    }

    public async Task<bool> Insert(Address address)
    {
        return await _repository.Insert(address);
    }

    public async Task<bool> Update(int existingId, Address theAddress)
    {
        return await _repository.Update(existingId, theAddress);
    }

     public async Task<bool> UpdateArea(AreaRequest theArea)
    {
        return await _repository.UpdateArea(theArea);
    }

     public async Task<bool> UpdateLandMark(LandMarkRequest theLandMark)
    {
        return await _repository.UpdateLandMark(theLandMark);
    }

     public async Task<bool> UpdateCity(CityRequest theCity)
    {
        return await _repository.UpdateCity(theCity);
    }

     public async Task<bool> UpdateState(StateRequest theState)
    {
        return await _repository.UpdateState(theState);
    }

     public async Task<bool> UpdatePincode(PincodeRequest thePincode)
    {
        return await _repository.UpdatePincode(thePincode);
    }



    public async Task<bool> Delete(int existingId)
    {
        return await _repository.Delete(existingId);
    }
}
