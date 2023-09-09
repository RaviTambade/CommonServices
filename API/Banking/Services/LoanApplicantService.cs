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
    
    public bool Insert(LoanApplicants applicant)
    {
        Console.WriteLine("ADHAR ID SERVICE : "+ applicant.AadharId);
        bool status=_repo.Insert(applicant);
        return status;
    }   
    
}
