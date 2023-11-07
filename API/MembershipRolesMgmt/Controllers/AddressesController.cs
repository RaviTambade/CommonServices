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
    public async Task<List<Address>> GetAllAddresses(int userId)
    {
        return await _service.GetAllAddresses(userId);
    }

    [HttpGet("info/{addressIds}")]
    public async Task<List<Address>> GetAllAddresses(string addressIds)
    {
        return await _service.GetAllAddresses(addressIds);
    }


    [HttpPost]
    public async Task<bool> Insert(Address address)
    {
        return await _service.Insert(address);
    }
}
