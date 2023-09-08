using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


namespace BankingServices.Controllers;

[ApiController]
[Route("/api/loans")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _svc;

    public LoanController(ILoanService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    public IEnumerable<Loan> GetAll()
    {
        IEnumerable<Loan> loans = _svc.GetAll();
        return loans;
    }
    
}
