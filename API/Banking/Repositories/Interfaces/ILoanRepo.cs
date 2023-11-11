using EntityLib;

namespace RepoLib;

public interface ILoanRepo
{
    List<Loan> GetAll();
    Loan GetByAccountId(int accountId);
    bool Insert(Loan loans);
    bool Delete(int loanId);
    bool Update(Loan loan);

}
