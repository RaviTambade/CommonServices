using PersonalInfoAPI.Models;
using PersonalInfoAPI.Repositories.Interfaces;
using PersonalInfoAPI.Services.Interfaces;

namespace PersonalInfoAPI.Services;

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