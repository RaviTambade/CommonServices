using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Corporate.Models;
using Corporate.Services.Interfaces;

namespace Corporate.Controllers;

[ApiController]
[Route("api/corporates")]
public class CorporatesController : ControllerBase
{
    private readonly ICorporateService _svc;

    public CorporatesController(ICorporateService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    public async Task<List<Corporation>> GetAll()
    {
        List<Corporation> corporates = await _svc.GetAll();
        return corporates;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Corporation> Get(int id)
    {
        Corporation corporate = await _svc.GetById(id);
        return corporate;
    }

    [HttpGet]
    [Route("person/{personId}")]
    public async Task<int> GetCorporateIdByPersonId(int personId)
    {
        return await _svc.GetCorporateIdByPersonId(personId);
    }

    [HttpGet]
    [Route("names/{id}")]
    public async Task<List<CorporateNameWithId>> GetNames(string id)
    {
        return await _svc.GetNames(id);
    }

    [HttpPost]
    public async Task<bool> Insert([FromBody] Corporation corporate)
    {
        bool status = await _svc.Insert(corporate);
        return status;
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<bool> Update(int id, Corporation corporate)
    {
        bool status = await _svc.Update(id, corporate);
        return status;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<bool> Delete(int id)
    {
        bool status = await _svc.Delete(id);
        return status;
    }



    [HttpGet]
    [Route("{name}/details")]
    public async Task<Corporation> GetByName(string name)
    {
       return await _svc.GetByName(name);
    }

}
