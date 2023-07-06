using PersonalInfoAPI.Models;
using PersonalInfoAPI.Repositories.Interfaces;
using PersonalInfoAPI.Services.Interfaces;

namespace PersonalInfoAPI.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repo;

    public AddressService(IAddressRepository repo)
    {
        _repo = repo;
    }

    public bool Insert(Address theAddress)
    {
        return _repo.Insert(theAddress);
    }

    public bool Update(Address theAddress)
    {
         return _repo.Update(theAddress);
    }
} 