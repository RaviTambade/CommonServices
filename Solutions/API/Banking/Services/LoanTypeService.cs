namespace ServicesLib;

using System.Collections.Generic;
using EntityLib;
using RepoLib;

public class LoanTypeService : ILoanTypeService
{
    
    public readonly ILoanTypeRepo _repo;
    public LoanTypeService(ILoanTypeRepo repo)
    {
        _repo = repo;
    }

    public List<LoanType> GetAll()
    {
        List<LoanType> loantypelist=_repo.GetAll();
        return loantypelist;
    }

    public LoanType GetByLoanTypeId(int loantypeId)
    {
      LoanType loantype  = _repo.GetByLoanTypeId(loantypeId);
    return loantype; 
    }
}
