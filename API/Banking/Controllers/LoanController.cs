using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


namespace BankingServices.Controllers;

[ApiController]
[Route("/api/loan")]
public class LoanController : ControllerBase
{
  //  private readonly ILoanService _svc;

    public LoanController()
    {
        
    }

    [HttpGet]
    public IEnumerable<Loan> GetAll()
    {
        IEnumerable<Loan> loans = _svc.GetAll();
        return loans;
    }

    [HttpGet]
    [Route("{acctno}")]
    public Account GetByAccountNumber(string acctno)
    {
        Account account = _svc.GetByAccountNumber(acctno);
        return account;
    }

    [HttpPost]
    [Route("details")]
    public async Task<AccountInfo> GetAccountInfo(CustomerDependancyCondition condition)
    {
        return await _svc.GetAccountInfo(condition);
    }

    [HttpPut]
    public bool Update(Account account)
    {
        bool stauts = _svc.Update(account);
        return stauts;
    }

    [HttpPost]
    public bool Insert(Account account)
    {
        bool status = _svc.Insert(account);
        return status;
    }

    [HttpDelete]
    [Route("{accountNumber}")]
    public bool Delete(string accountNumber)
    {
        bool stauts = _svc.Delete(accountNumber);
        return stauts;
    }
}
