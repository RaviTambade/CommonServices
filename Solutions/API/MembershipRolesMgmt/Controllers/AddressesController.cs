using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/addresses")]
[EnableCors("AllowSpecificOrigin")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _service;

    public AddressesController(IAddressService service)
    {
        _service = service;
    }

    [HttpGet("users/{userId}")]
    public async Task<List<Address>> GetAllAddresses(int userId)
    {
        return await _service.GetAllAddresses(userId);
    }

    [HttpGet("{addressId}")]
    public async Task<Address> GetAddress(int addressId)
    {
        return await _service.GetAddress(addressId);
    }

    [HttpPost]
    public async Task<bool> Insert(Address address)
    {
        return await _service.Insert(address);
    }

    [HttpPut("{existingId}")]
    public async Task<bool> Update(int existingId, Address theAddress)
    {
        return await _service.Update(existingId, theAddress);
    }

    [HttpPut("update/area")]
    public async Task<bool> UpdateArea(AreaRequest theAreaRequest)
    {
        return await _service.UpdateArea(theAreaRequest);
    }

    [HttpPut("update/landmark")]
    public async Task<bool> UpdateLandMark(LandMarkRequest theLandMarkRequest)
    {
        return await _service.UpdateLandMark(theLandMarkRequest);
    }

    [HttpPut("update/city")]
    public async Task<bool> UpdateCity(CityRequest theCity)
    {
        return await _service.UpdateCity(theCity);
    }

    [HttpPut("update/state")]
    public async Task<bool> UpdateState(StateRequest theState)
    {
        return await _service.UpdateState(theState);
    }

    [HttpPut("update/pincode")]
    public async Task<bool> UpdatePincode(PincodeRequest thePincode)
    {
        return await _service.UpdatePincode(thePincode);
    }

    [HttpDelete("{existingId}")]
    public async Task<bool> Delete(int existingId)
    {
        return await _service.Delete(existingId);
    }
}