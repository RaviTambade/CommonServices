using PersonalInfoAPI.Services.Interfaces;
using PersonalInfoAPI.Models;
using PersonalInfoAPI.Repositories.Interfaces;
namespace PersonalInfoAPI.Services;

public class PeopleService:IPeopleService{

    private readonly IPeopleRepository _repo;

    public PeopleService(IPeopleRepository repo){
        _repo=repo;
    }


    public async Task<List<People>> GetAllPeoples() => await _repo.GetAllPeoples();

    public async Task<bool> AddPerson(People people)=> await _repo.AddPerson(people);

    public async Task<bool> UpdatePerson(int id,People people)=> await _repo.UpdatePerson(id,people);
}