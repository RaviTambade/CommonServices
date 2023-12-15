using EntityLib;
using RepoLib;

namespace ServicesLib;


public class OperationsService:IOperationsService
{
    public readonly IOperationRepo _repo;
    public OperationsService(IOperationRepo repo)
    {
        _repo = repo;
    }
   public List<Operation> GetAllOperations()
    {
        List<Operation> operations=new List<Operation>();
        operations=_repo.GetAll();

        return operations;
    }    
  
    public List<Operation> GetAll()
    {
        List<Operation> operations=new List<Operation>();
        operations=_repo.GetAll();

        return operations;
    }

    public List<Operation> GetByAccountNumber(string acctNumber)
    {
       return _repo.GetByAccountNumber(acctNumber);
         
    }

    public bool Delete(string acctNumber)
    {
         bool status=_repo.Delete(acctNumber);
        return status;
    }

    public bool Insert(Operation opr)
    {
        bool status=_repo.Insert(opr);
         return status;
    }

    public bool Update(Operation opr)
    {
        bool status=_repo.Update(opr);
         return status;
    }

    public Operation GetById(int id)
    {
        return _repo.GetById(id);
    }

    public List<Operation> GetByMode(string mode)
    {
      return  _repo.GetByMode(mode);
    }

    public List<Statement> GetStatement(string acctNumber)
    {
       return _repo.GetStatement(acctNumber);
    }

    public bool ProcessAnualInterest(string acctnumber)
    {

        bool status = _repo.ProcessAnualInterest(acctnumber);

        return status;
        
    }

    public bool ProcessMonthlyEmi(string acctnumber)
    {

        bool status = _repo.ProcessMonthlyEmi(acctnumber);

        return status;
        
    }

     public LoanApplicantEMIDetails LoanEmiDetails(int loanId){
        LoanApplicantEMIDetails emidetails=_repo.LoanEmiDetails(loanId);
        return emidetails;
     }

    public Operation GetLoanApplicantEmiDetails(int loanId)
    {
        Operation loanapplicantemidetails = _repo.GetLoanApplicantEmiDetails(loanId);
        return loanapplicantemidetails;
    }
    
}
