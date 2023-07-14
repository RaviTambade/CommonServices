using EntityLib;

namespace RepoLib;

public interface IAccountRepo
{
    List<Account> GetAll();
    Account GetByAccountNumber(string acctNumber);
    AccountInfo GetAccountInfo(CustomerDependancyCondition condition);
    bool Delete(string acctNumber);
    bool Insert(Account acct);
    bool Update(Account acct);

    Account GetById(int Id);
}
