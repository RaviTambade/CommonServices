using Microsoft.AspNetCore.Mvc;
using  ServicesLib;
using EntityLib;
namespace BankingServices.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountsController : ControllerBase
{

    private readonly IBankingService _svc;
    public BankAccountsController(IBankingService svc)
    {
        _svc=svc;
    }

    [HttpGet]
    [Route("accounts")]
    public IEnumerable<Account> GetAll()
    {
        IEnumerable<Account> accounts = _svc.GetAll();
        return accounts;
    }
    [HttpGet]
    [Route("account/{acctno}")]
    public Account GetByAccountNumber(string acctno)
    {
        Account account = _svc.GetByAccountNumber(acctno);
        return account;
    }
    [HttpPut]
    [Route("account")]
    public bool Update(Account account)
    {
        bool stauts = _svc.Update(account);
        return stauts;
    }
    [HttpPost]
    [Route("account")]
    public bool Insert(Account account)
    {
        bool status = _svc.Insert(account);
        return status;
    }

    [HttpDelete]
    [Route("account/{accountNumber}")]
    public bool Delete(string accountNumber)
    {
        bool stauts = _svc.Delete(accountNumber);
        return stauts;
    }

}
