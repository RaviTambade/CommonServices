namespace ServicesLib;
using EntityLib;
using RepoLib;
// using BusinessLogic;
//Bussiness Logic Implementation
public class LoanApplicantService : ILoanApplicantService
{
    
    public readonly ILoanApplicantRepo _repo;
    public LoanApplicantService(ILoanApplicantRepo repo)
    {
        _repo = repo;
    }  
    
    public List<LoanApplicants> GetAll()
    {
        List<LoanApplicants> loanapplicants=new List<LoanApplicants>();
        loanapplicants=_repo.GetAll();
        return loanapplicants;
    }  
    public bool Insert(LoanApplicants applicant)
    {
        Console.WriteLine("Amount IN SERVICE : "+ applicant.Amount);
        bool status=_repo.Insert(applicant);
        return status;
    }   

    public async Task <bool> Update(LoanaplicantsInfo applicant)
    {
         Console.WriteLine("Status in Update method : "+ applicant.Status);
        bool status=await _repo.Update(applicant);
        return status;
    }


    public bool Delete(int applicantId)
    {
        bool status=_repo.Delete(applicantId);
        return status;
    }
    

    /*public LoanApplicants GetById(int laonapplicantId)
    {
        LoanApplicants loanapplicant=new LoanApplicants();
        loanapplicant=_repo.GetById(laonapplicantId);
        return loanapplicant;
    }*/

    public async Task<LoanaplicantsInfo> GetById(int laonapplicantId)
    {
        LoanaplicantsInfo loanapplicant=new LoanaplicantsInfo();
        loanapplicant=await _repo.GetById(laonapplicantId);
        return loanapplicant;
    }
    
    public List<LoanApplicants> LoanApplicantsBetweenGivenDates(DateTime startDate,DateTime endDate)
    {
        List<LoanApplicants> loanapplicants=new List<LoanApplicants>();
        loanapplicants=_repo.LoanApplicantsBetweenGivenDates(startDate,endDate);
        return loanapplicants;
    }

     public async Task<List<LoanaplicantsInfo>> LoanApplicantsAccordingLoanStatus(string LoanType)
     {
        List<LoanaplicantsInfo> loanapplicants=new List<LoanaplicantsInfo>();
        loanapplicants=await _repo.LoanApplicantsAccordingLoanStatus(LoanType);
        return loanapplicants;
     }

     public async Task<List<LoanaplicantsInfo>> GetAllapplicantInfo()
     {
        Console.WriteLine("Inside LoanaplicantsInfo method in Service....");
        List<LoanaplicantsInfo> loanapplicants=new List<LoanaplicantsInfo>();
        loanapplicants=await _repo.GetAllapplicantInfo();
        
        return loanapplicants;
     }
}
