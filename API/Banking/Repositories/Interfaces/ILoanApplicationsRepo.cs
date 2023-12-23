using EntityLib;

namespace RepoLib;

public interface ILoanApplicationsRepo
{
    bool Insert(LoanApplications application);
    public Task <bool> UpdateStatus(LoanApplications application);

    public bool Delete(int laonapplicantionId);
    public List<LoanApplications> GetAll();
    public  Task <LoanaplicationInfo> GetById(int laonapplicationId);
    public List<LoanApplicationDetails> LoanApplicationBetweenGivenDates(DateTime startDate,DateTime endDate);

    public Task <List<LoanaplicationInfo>> LoanApplicationAccordingLoanStatus(string LoanType);//Why need not to write async here before Task

    //public List<LoanApplicants> LoanApplicantsAccordingLoanStatus(string LoanType);

    public  Task<List<LoanaplicationInfo>> GetAllapplicationInfo();

}
