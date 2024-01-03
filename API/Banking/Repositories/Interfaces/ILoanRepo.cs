using EntityLib;

namespace RepoLib;

public interface ILoanRepo
{
    List<Loan> GetAll();
    Loan GetByLoanId(int loanId);
    bool Insert(Loan loans);
    bool Delete(int loanId);
    bool Update(Loan loan);

}
