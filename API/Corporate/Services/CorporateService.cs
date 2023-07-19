using System.Collections;
using System.Threading.Tasks;
using Corporate.Models;
using Corporate.Repositories.Interfaces;
using Corporate.Services.Interfaces;

namespace Corporate.Services;

public class CorporateService : ICorporateService
{
    private readonly ICorporateRepository _repo;

    public CorporateService(ICorporateRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Corporation>> GetAll() => await _repo.GetAll();

    public async Task<Corporation> GetById(int id) => await _repo.GetById(id);

    public async Task<List<CorporateNameWithId>> GetNames(string id) => await _repo.GetNames(id);

    public async Task<int> GetCorporateIdByPersonId(int personId) =>
        await _repo.GetCorporateIdByPersonId(personId);

    public async Task<bool> Insert(Corporation corporate) => await _repo.Insert(corporate);

    public async Task<bool> Update(int id, Corporation corporate) =>
        await _repo.Update(id, corporate);

    public async Task<bool> Delete(int id) => await _repo.Delete(id);
}
