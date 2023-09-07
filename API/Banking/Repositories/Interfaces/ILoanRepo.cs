using EntityLib;

namespace RepoLib;

public interface ILoanRepo
{
    List<Loan> GetAll();
    Loan GetByLoanId(int loanID);
   // Task<AccountInfo> GetAccountInfo(CustomerDependancyCondition condition);
    bool Delete(int loanID);
    bool Insert(Loan loan);
    bool Update(Loan acloanct);
    Account GetByAccountId(int accountId);
}
