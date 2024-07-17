using EntityLib;

namespace RepoLib;

public interface ILoanTypeRepo
{
    List<LoanType> GetAll();
    LoanType GetByLoanTypeId(int loantypeId);
}