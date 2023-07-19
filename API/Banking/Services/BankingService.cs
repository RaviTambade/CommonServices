namespace ServicesLib;
using EntityLib;
using RepoLib;
// using BusinessLogic;
using RepoLib;
//Bussiness Logic Implementation
public class BankingService : IBankingService
{
    
    public readonly IAccountRepo _repo;
    public BankingService(IAccountRepo repo)
    {
        _repo = repo;
    }

    public List<Account> GetAll()
    {
        List<Account> accounts=new List<Account>();
        accounts=_repo.GetAll();
        return accounts;
    }

    public Account GetByAccountNumber(string accountNumber)
    {
        Account account=new Account();
        account=_repo.GetByAccountNumber(accountNumber);
        return account;
    }

     public async  Task<AccountInfo> GetAccountInfo(CustomerDependancyCondition condition)
    {
       return await _repo.GetAccountInfo(condition);
    }

    public Account GetById(int id)
     {
        Account acct  = _repo.GetById(id);
        return acct;
     }
    public bool Delete(string acctNumber)
    {
        bool status=_repo.Delete(acctNumber);
        return status;
    }

    public bool Insert(Account acct)
    {
         bool status=_repo.Insert(acct);
         return status;
    }
    public bool Update(Account acct)
    {
        bool status=_repo.Update(acct);
         return status;
    }
    
}
