using EntityLib;

namespace RepoLib;

public interface ILoanTypeRepo
{
    LoanType GetByLoanTypeId(int loantypeId);
}