using Microsoft.AspNetCore.Mvc;
using EntityLib;
using ServicesLib;
namespace OperationsServices.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class OperationsController : ControllerBase
{

    private readonly IOperationsService _svc;
    public OperationsController(IOperationsService svc)
    {
        _svc=svc;
    }

   
//Get all Operations in bank
//[Route("banking/operations/")]
 [HttpGet]
[Route("operations")]
 public List<Operation> GetAllOperations()
    {
        List<Operation> operations= _svc.GetAll();
        return operations;
    }    
    

//http:localhost:5656/account/56756/completestatement
[HttpGet]
//[Route("account/{acctNumber}/statement")]
[Route("operationsbyaccountnumber/{acctNumber}")]
public  Operation GetOperationByAccountNumber(string acctNumber)
    {
        Operation opeartion=_svc.GetByAccountNumber(acctNumber);
        return opeartion;
   
    }




//http:localhost:5656/account/56756/mode/credit/statement
//get statement of account number which are credited
//[Route("banking/accounts/{acctNumber}/mode/{mode}/statement")]

/*


*/

[HttpGet]
[Route("{mode}")]
  public  List<Operation> GetOperations(char mode)
    {
        List<Operation> operations=_svc.GetByMode(mode);
        return operations;
    }    
   




//[Route("banking/operations/{operationid}")]
   [HttpGet]
   [Route("operationsbyid")]
    Operation GetOperationDetails(int id)
    {
        Operation opr  = _svc.GetById(id);
        return opr;
    }
    
    
    //[Route("banking/operations/{operationid}")]
    [HttpDelete]
    [Route("Delete")]
     public bool Delete(string acctNumber)
    {
        bool status=_svc.Delete(acctNumber);
        return status;
    }
    


    // HTTP Verb: POST   url: http://banking/operaionts
    //body: operation object
    //[Route("banking/operations")]
    [HttpPost]
     [Route("Insert")]
     public bool Insert(Operation opr)
    {
        bool status=_svc.Insert(opr);
         return status;
    }

    // HTTP Verb: PUT   url: http://banking/operaionts/456545
    //body: operation object
    //[Route("banking/operations/{operationid}")]
    [HttpPut]
    [Route("Update")]
   public  bool Update(Operation opr)
    {
        bool status=_svc.Update(opr);
         return status;
    }
}
