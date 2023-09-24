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
    public async Task<List<Address>> GetAddresses(int userId)
    {
        return await _service.GetAddresses(userId);
    }

    [HttpPost]
    public async Task<bool> Add(Address address)
    {
        return await _service.Add(address);
    }
}
