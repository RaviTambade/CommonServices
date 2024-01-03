using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


namespace BankingServices.Controllers;

[ApiController]
[Route("/api/loanstypes")]
public class LoanTypeController : ControllerBase
{
    private readonly ILoanTypeService _svc;

    public LoanTypeController(ILoanTypeService svc)
    {
        _svc = svc;
    }

   [HttpGet]
   public List<LoanType> GetAll(){
       List<LoanType> newloantype=_svc.GetAll();
       return newloantype;
   }
    
    
    [HttpGet]
    [Route("{loantypeid}")]
    public LoanType GetByLoanTypeId(int loantypeid)
    {
        LoanType loantypename = _svc.GetByLoanTypeId(loantypeid);
        return loantypename;
    }   
   
}
