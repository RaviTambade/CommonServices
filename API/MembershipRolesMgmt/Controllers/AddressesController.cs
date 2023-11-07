using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Controllers;

[ApiController]
[Route("/api/addresses")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _service;

    public AddressesController(IAddressService service)
    {
        _service = service;
    }

    [HttpGet("{userId}")]
    public async Task<List<Address>> GetAddressesofUser(int userId)
    {
        return await _service.GetAddressesofUser(userId);
    }

    [HttpGet("info/{addressIds}")]
    public async Task<List<Address>> GetAddressesInformation(string addressIds)
    {
        return await _service.GetAddressesInformation(addressIds);
    }

    [HttpGet("details/{addressId}")]
    public async Task<Address?> GetAddress(int addressId)
    {
        return await _service.GetAddress(addressId);
    }

    [HttpPost("nearest")]
    public async Task<int> GetNearestAddress([FromBody] AddressIdRequest request)
    {
        return await _service.GetNearestAddressId(request);
    }

    [HttpPost]
    public async Task<bool> Create(Address address)
    {
        return await _service.Insert(address);
    }
}
