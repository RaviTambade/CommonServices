using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


namespace BankingServices.Controllers;

[ApiController]
[Route("/api/accounts")]
public class BankAccountsController : ControllerBase
{
    private readonly IBankingService _svc;

    public BankAccountsController(IBankingService svc)
    {
        _svc = svc;
    }

    [HttpGet]
    public IEnumerable<Account> GetAll()
    {
        IEnumerable<Account> accounts = _svc.GetAll();
        return accounts;
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
