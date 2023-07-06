using UsersManagement.Models;
using UsersManagement.Repositories.Interfaces;
using UsersManagement.Services.Interfaces;

namespace UsersManagement.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _repo;

    public LocationService(ILocationRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Insert(Location theAddress)
    {
        return await _repo.Insert(theAddress);
    }

    public async Task<bool> Update(Location theAddress)
    {
        return await _repo.Update(theAddress);
    }
} 