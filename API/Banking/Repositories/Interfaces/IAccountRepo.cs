using EntityLib;
namespace RepoLib;

public interface IAccountRepo
{
     List<Account> GetAll();    
    Account GetByAccountNumber(string acctNumber);
    bool Delete(string acctNumber);
    bool Insert(Account acct);
    bool Update(Account acct);   
   
    Account GetById(int Id);
}
