using PersonalInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using PersonalInfoAPI.Services.Interfaces;

namespace PersonalInfoAPI.Controller;

[ApiController]
[Route("/api/[Controller]")]
public class PeoplesController: ControllerBase{

    private readonly IPeopleService _svc;

    public PeoplesController(IPeopleService svc)
    {
       _svc=svc;
    }

    [HttpPost]
    [Route("addpeople")]

    public async Task<bool> AddPerson(People people)
    {
        bool status = await _svc.AddPerson(people);
        return status;

    }

    [HttpPut]
    [Route("updatepeople/{id}")]

    public async Task<bool> UpdatePerson(int id,People people)
    {
        bool status = await _svc.UpdatePerson(id,people);
        return status;

    }

    [HttpGet]
    [Route("getall")]

    public async Task<List<People>> GetAllPeoples()
    {
        List<People> peoples = await _svc.GetAllPeoples();
        return peoples;
    }



    [HttpGet]
    [Route("getDetails/{aaddharid}")]

    public async Task<People> GetDetails(string aaddharid)
    {
        People people = await _svc.GetDetails(aaddharid);
        return people;
    }


    [HttpDelete]
    [Route("DeletePeople/{aaddharid}")]

    public async Task<bool> DeletePeople(string aaddharid)
    {
        bool status = await _svc.DeletePeople(aaddharid);
        return status;
    }

    [HttpGet]
    [Route("{peopleid}")]
    public async Task<People> GetPeople(int peopleId){
        return await _svc.GetPeople(peopleId);
    }

}