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
<<<<<<< HEAD
        Console.WriteLine("Amount CONTROLLER : "+ applicant.Amount);
=======
        Console.WriteLine("ADHAR ID CONTROLLER : "+ applicant.AadharId);
        Console.WriteLine("ADHAR ID CONTROLLER : "+ applicant.ToString());
>>>>>>> 93a4fa34feb3b14e0953e49a9b3a34dc40cb29b6
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
