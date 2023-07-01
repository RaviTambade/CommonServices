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
        Console.WriteLine(people.ContactNumber);
        Console.WriteLine(people.FirstName);
        Console.WriteLine(people.LastName);
        Console.WriteLine(people.Email);
        Console.WriteLine(people.Gender);
        Console.WriteLine(people.BirthDate);
        Console.WriteLine(people.AadharId);

        bool status = await _svc.UpdatePerson(id,people);
        return status;

    }
}