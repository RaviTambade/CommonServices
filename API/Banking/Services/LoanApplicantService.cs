namespace ServicesLib;
using EntityLib;
using RepoLib;
// using BusinessLogic;
//Bussiness Logic Implementation
public class LoanApplicationsService : ILoanApplicationsService
{
    
    public readonly ILoanApplicationsRepo _repo;
    public LoanApplicationsService(ILoanApplicationsRepo repo)
    {
        _repo = repo;
    }  
    
    public List<LoanApplications> GetAll()
    {
        List<LoanApplications> loanapplicants=new List<LoanApplications>();
        loanapplicants=_repo.GetAll();
        return loanapplicants;
    }  
    public bool Insert(LoanApplications application)
    {
        Console.WriteLine("Amount IN SERVICE : "+ application.LoanAmount);
        bool status=_repo.Insert(application);
        return status;
    }   

    public async Task <bool> UpdateStatus(LoanApplications application)
    {
         Console.WriteLine("Status in Update method : "+ application.LoanStatus);
        bool status=await _repo.UpdateStatus(application);
        return status;
    }


    public bool Delete(int applicationId)
    {
        bool status=_repo.Delete(applicationId);
        return status;
    }
    

    /*public LoanApplicants GetById(int laonapplicantId)
    {
        LoanApplicants loanapplicant=new LoanApplicants();
        loanapplicant=_repo.GetById(laonapplicantId);
        return loanapplicant;
    }*/

    public async Task<LoanResponse> GetById(int laonapplicationId)
    {
        LoanResponse loanapplication=new LoanResponse();
        loanapplication=await _repo.GetById(laonapplicationId);
        return loanapplication;
    }
    
   public async Task<List<LoanResponse> >GetAllLoans(DateTime startDate,DateTime endDate)
    {
        List<LoanResponse> loanapplications=new List<LoanResponse>();
        loanapplications=await _repo.GetAllLoans(startDate,endDate);
        return loanapplications;
    }

    public async Task<List<LoanResponse>> GetAllLoans(string LoanType)
     {
        List<LoanResponse> loanapplication=new List<LoanResponse>();
        loanapplication=await _repo.GetAllLoans(LoanType);
        return loanapplication;
    }
    
    public async Task<List<LoanResponse>> GetAllapplicantsInfo()
    {
        Console.WriteLine("Inside LoanaplicantsInfo method in Service....");
        List<LoanResponse> loanapplications=new List<LoanResponse>();
        loanapplications=await _repo.GetAllapplicantsInfo();
        
        return loanapplications;
    }
}
