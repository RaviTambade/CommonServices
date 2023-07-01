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


}