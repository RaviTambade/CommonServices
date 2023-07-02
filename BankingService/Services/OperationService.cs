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

    public Operation GetByAccountNumber(string acctNumber)
    {
       Operation opeartion=new Operation();
        opeartion=_repo.GetByAccountNumber(acctNumber);
        return opeartion;
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

    public Operation GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public List<Operation> GetByMode(char Mode)
    {
        throw new NotImplementedException();
    }
}