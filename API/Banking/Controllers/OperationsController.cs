using EntityLib;
using Microsoft.AspNetCore.Mvc;
using ServicesLib;
namespace OperationsServices.Controllers;

[ApiController]
[Route("/api/banking")]
public class OperationsController : ControllerBase
{

    private readonly IOperationsService _svc;
    public OperationsController(IOperationsService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    [Route("operations")]
    public List<Operation> GetAll()
    {
        List<Operation> operations = _svc.GetAll();
        return operations;
    }

      [HttpGet]
    [Route("operations/mode/{mode}")]
    public List<Operation> GetAll(string mode)
    {
        Console.WriteLine(mode);
        List<Operation> operations = _svc.GetByMode(mode);
        return operations;
    }

    [HttpGet]
    [Route("accounts/{acctNumber}/operations")]
    public List<Operation> GetByAccountNumber(string acctNumber)
    {
        Console.WriteLine(acctNumber);
        List<Operation> operations = _svc.GetByAccountNumber(acctNumber);
        return operations;
    }

  

    [HttpGet]
    [Route("operations/{id}")]
    public Operation GetById(int id)
    {
        Operation opr = _svc.GetById(id);
        return opr;
    }

    [HttpGet]
    [Route("accounts/{acctnumber}/operations/mode/{mode}")]
    public List<Operation> Get(int acctNumber,string mode)
    {
    Console.WriteLine(mode);
    Console.WriteLine(acctNumber);
        List<Operation> operations = _svc.GetByMode(mode);
        return operations;
    }

    [HttpDelete]
    [Route("accounts/{acctNumber}/operations")]
    public bool Delete(string acctNumber)
    {
        bool status = _svc.Delete(acctNumber);
        return status;
    }

    [HttpPost]
    [Route("operations")]
    public bool Insert(Operation opr)
    {
        bool status = _svc.Insert(opr);
        return status;
    }


    [HttpPut]
    [Route("operations")]
    public bool Update(Operation opr)
    {
        bool status = _svc.Update(opr);
        return status;
    }
}
