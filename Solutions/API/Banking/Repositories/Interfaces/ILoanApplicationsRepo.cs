using EntityLib;

namespace RepoLib;

public interface ILoanApplicationsRepo
{
    bool Insert(LoanApplications application);
    public Task <bool> UpdateStatus(LoanApplications application);

    public bool Delete(int laonapplicantionId);
    public List<LoanApplications> GetAll();
    public  Task <LoanResponse> GetById(int laonapplicationId);
    public Task<List<LoanResponse> >GetAllLoans(DateTime startDate,DateTime endDate);

    public Task <List<LoanResponse>> GetAllLoans(string LoanType);//Why need not to write async here before Task

    //public List<LoanApplicants> LoanApplicantsAccordingLoanStatus(string LoanType);

    public  Task<List<LoanResponse>> GetAllapplicantsInfo();

}
