using EntityLib;

namespace RepoLib;

public interface ILoanApplicantRepo
{
    bool Insert(LoanApplicants applicant);
    public Task <bool> UpdateStatus(LoanaplicantsInfo applicant);

    public bool Delete(int laonapplicantId);
    public List<LoanApplicants> GetAll();
    public  Task <LoanaplicantsInfo> GetById(int laonapplicantId);
    public List<LoanApplicants> LoanApplicantsBetweenGivenDates(DateTime startDate,DateTime endDate);

    public Task <List<LoanaplicantsInfo>> LoanApplicantsAccordingLoanStatus(string LoanType);//Why need not to write async here before Task

    //public List<LoanApplicants> LoanApplicantsAccordingLoanStatus(string LoanType);

    public  Task<List<LoanaplicantsInfo>> GetAllapplicantInfo();

}
