using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;
using UsersManagement.Services.Interfaces;

namespace UsersManagement.Services;

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