using Microsoft.AspNetCore.Mvc;
using EntityLib;
using ServicesLib;
namespace OperationsServices.Controllers;

[ApiController]
[Route("[controller]")]
public class OperationsController : ControllerBase
{

    private readonly IOperationsService _svc;
    public OperationsController(IOperationsService svc)
    {
        _svc=svc;
    }

   

 [HttpGet]
[Route("operations")]
 public List<Operation> GetAllOperations()
    {
        List<Operation> operations= _svc.GetAll();
        return operations;
    }    
    
    

[HttpGet]
[Route("operationsbyaccountnumber")]
public  Operation GetOperationByAccountNumber(string acctNumber)
    {
        Operation opeartion=_svc.GetByAccountNumber(acctNumber);
        return opeartion;
   
    }



[HttpGet]
[Route("operationsbymode")]
    List<Operation> GetOperationsByMode(char mode)
    {
    
        List<Operation> operations=_svc.GetByMode(mode);
        return operations;
    }    
   
   [HttpGet]
   [Route("operationsbyid")]
    Operation GetOperationById(int id)
    {
        Operation opr  = _svc.GetById(id);
        return opr;
    }
    
    
    [HttpDelete]
    [Route("Delete")]
     public bool DeleteOperation(string acctNumber)
    {
        bool status=_svc.Delete(acctNumber);
        return status;
    }
    
    [HttpPost]
     [Route("Insert")]
     public bool InsertOperation(Operation opr)
    {
        bool status=_svc.Insert(opr);
         return status;
    }


    [HttpPut]
    [Route("Update")]
   public  bool UpdateOperation(Operation opr)
    {
        bool status=_svc.Update(opr);
         return status;
    }
}
