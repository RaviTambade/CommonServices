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

    public bool Delete(int applicantId)
    {
        bool status=_repo.Delete(applicantId);
        return status;
    }
    


    
}
