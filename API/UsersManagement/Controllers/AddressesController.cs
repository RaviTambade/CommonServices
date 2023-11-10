using UsersManagement.Models;
using UsersManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UsersManagement.Controllers;

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
    public async Task<List<AddressInfo>> GetAddresses(int userId)
    {
        return await _service.GetAddresses(userId);
    }

    [HttpGet("details/{addressId}")]
    public async Task<AddressInfo?> GetAddressInfo(int addressId)
    {
        return await _service.GetAddressInfo(addressId);
    }
    [HttpGet("info/{addressIdString}")]
   public async Task<List<AddressInfo>> GetAddressesInformationFromId(string addressIdString)
    {
        return await _service.GetAddressesInformationFromId(addressIdString);
    }

    [HttpPost]
    public async Task<bool> Add(Address address)
    {
        return await _service.Add(address);
    }

    [HttpPost("nearest")]
    public async Task<int> GetNearestAddressId([FromBody] AddressIdRequest request)
    {
        return await _service.GetNearestAddressId(request);
    }
}
