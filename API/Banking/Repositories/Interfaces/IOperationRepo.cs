using EntityLib;
namespace RepoLib;

public interface IOperationRepo
{
    List<Operation> GetAll();    
    List<Operation> GetByAccountNumber(string acctNumber);
    List<Statement> GetStatement(string acctNumber);
    bool Delete(string acctNumber);
    bool Insert(Operation opr);
    bool Update(Operation opr);   
    Operation GetById(int Id);

    List<Operation> GetByMode(string Mode);

    /*List<Operation> GetByToAccount(int id);

    List<Operation> GetByFromAccount(int id);*/
   
}