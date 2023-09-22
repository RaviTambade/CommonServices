using EntityLib;

namespace RepoLib;

public interface ILoanApplicantRepo
{
    bool Insert(LoanApplicants applicant); 
    public bool Delete(int laonapplicantId);
    public List<LoanApplicants> GetAll();
    public LoanApplicants GetById(int laonapplicantId);

}
