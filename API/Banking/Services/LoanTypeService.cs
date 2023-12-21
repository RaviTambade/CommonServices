namespace ServicesLib;
using EntityLib;
using RepoLib;

public class LoanTypeService : ILoanTypeService
{
    
    public readonly ILoanTypeRepo _repo;
    public LoanTypeService(ILoanTypeRepo repo)
    {
        _repo = repo;
    }

    public LoanType GetByLoanTypeId(int loantypeId)
    {
      LoanType loantype  = _repo.GetByLoanTypeId(loantypeId);
    return loantype; 
    }
}
