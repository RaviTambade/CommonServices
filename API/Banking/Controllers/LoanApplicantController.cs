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

    [HttpGet]
    public IEnumerable<LoanApplicants> GetAll()
    {
        IEnumerable<LoanApplicants> applicants = _svc.GetAll();
        return applicants;
    }
    [HttpPost]
    public bool Insert(LoanApplicants applicant)
    {
        Console.WriteLine("Amount CONTROLLER : "+ applicant.Amount);
        bool status = _svc.Insert(applicant);
        return status;
    }     

    [HttpDelete]
    [Route("{id}")]
    public bool Delete(int id)
    {
        bool stauts = _svc.Delete(id);
        return stauts;
    }


}
