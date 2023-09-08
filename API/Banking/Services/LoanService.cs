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
    
}
