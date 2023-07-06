using EntityLib;
namespace RepoLib;

public interface IOperationRepo
{
    List<Operation> GetAll();    
    Operation GetByAccountNumber(string acctNumber);
    bool Delete(string acctNumber);
    bool Insert(Operation opr);
    bool Update(Operation opr);   

    Operation GetById(int Id);

    List<Operation> GetByMode(char Mode);

    /*List<Operation> GetByToAccount(int id);

    List<Operation> GetByFromAccount(int id);*/
   
}