using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


namespace BankingServices.Controllers;

[ApiController]
[Route("/api/applicant")]
public class LoanApplicantController : ControllerBase
{
    private readonly ILoanApplicantService _svc; 

    public LoanApplicantController(ILoanApplicantService svc)
    {
        _svc = svc;
    }    

    [HttpPost]
    public bool Insert(LoanApplicants applicant)
    {
        Console.WriteLine("ADHAR ID CONTROLLER : "+ applicant.AadharId);
        Console.WriteLine("ADHAR ID CONTROLLER : "+ applicant.ToString());
        bool status = _svc.Insert(applicant);
        return status;
    }  
    
}
