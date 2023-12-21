namespace ServicesLib;
using EntityLib;
using RepoLib;
// using BusinessLogic;
//Bussiness Logic Implementation
public class LoanService : ILoanService
{
    
    public readonly ILoanRepo _repo;
    public LoanService(ILoanRepo repo)
    {
        _repo = repo;
    }

    public List<Loan> GetAll()
    {
        List<Loan> loans=new List<Loan>();
        loans=_repo.GetAll();
        return loans;
    }  

    public Loan GetByLoanId(int loanId)
    {
        Loan loan  = _repo.GetByLoanId(loanId);
        return loan;
    }

    public bool Insert(Loan loan)
    {
        bool status=_repo.Insert(loan);
        return status;
    }

    public bool Delete(int loanId)
    {
        bool status=_repo.Delete(loanId);
        return status;
    }

    public bool Update(Loan loan)
    {
        bool status=_repo.Update(loan);
        return status;
    }
    
}
