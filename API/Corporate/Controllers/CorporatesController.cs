using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Corporate.Models;
using Corporate.Services.Interfaces;
namespace Corporate.Controllers;


[ApiController]
[Route("api/corporates")]
public class CorporatesController : ControllerBase
{

    private readonly ICorporateService _svs;

    public CorporatesController(ICorporateService svc)
    {
        _svs=svc;
    }

    [HttpGet]
    [Route("")]
    public async Task<List<Corporation>> GetAll()
    {
        List<Corporation> corporates =await _svs.GetAll();
        return corporates;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Corporation> Get(int id)
    {
        Corporation corporate =await _svs.GetById(id);
        return corporate;
    }


    [HttpPost]
    [Route("add")]
    public async Task<bool> Insert([FromBody] Corporation corporate)
    {
        bool status =await _svs.Insert(corporate);
        return status;
    }

        //remove all items from cart 
    [HttpPut]
    [Route("update/{id}")]
    public async Task<bool> Update(int id,Corporation corporate)
    {
        bool status =await _svs.Update(id,corporate);
        return status;
    }

    //delete cartitem
    [HttpDelete]
    [Route("remove/{id}")]
    public async Task<bool> Delete(int id)
    {
        bool status =await _svs.Delete(id);
        return status;
    }



}
