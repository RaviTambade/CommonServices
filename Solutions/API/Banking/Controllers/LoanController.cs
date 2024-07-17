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

    [HttpGet]
    [Route("{loanid}")]
    public Loan GetByLoanId(int loanid)
    {
        Loan loan = _svc.GetByLoanId(loanid);
        return loan;
    }

    [HttpPost]
    public bool Insert(Loan loan)
    {
        bool status = _svc.Insert(loan);
        return status;
    }

    [HttpDelete]
    [Route("{loanid}")]
    public bool Delete(int loanid)
    {
        bool stauts = _svc.Delete(loanid);
        return stauts;
    }

    [HttpPut]
    [Route("{loanid}")]
    public bool Update(Loan loan)
    {
        bool stauts = _svc.Update(loan);
        return stauts;
    }

}
