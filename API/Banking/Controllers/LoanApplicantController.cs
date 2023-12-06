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
        Console.WriteLine("Ctr is called......");
        _svc = svc;
    }

    [HttpGet]

    public IEnumerable<LoanApplicants> GetAll()
    {
        Console.WriteLine("Inside getall method....");
        IEnumerable<LoanApplicants> applicants = _svc.GetAll();
        return applicants;
    }

    [HttpPost]
    public bool Insert(LoanApplicants applicant)
    {
         Console.WriteLine("Inside Insert method ......");
        Console.WriteLine("Amount CONTROLLER : " + applicant.Amount);
        Console.WriteLine("Account ID In Repo:- " + applicant.AccountId);
        Console.WriteLine("ApplayDate In Repo:- " + applicant.ApplyDate);
        Console.WriteLine("LoanType In Repo:- " + applicant.LoanType);
        Console.WriteLine("PanId In Repo:- " + applicant.PanId);

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

    [HttpGet]
    [Route("{id}")]
    public LoanApplicants GetById(int id)
    {
        LoanApplicants applicant = _svc.GetById(id);
        return applicant;
    }

    [HttpGet("{startDate}/{endDate}")]
     public IEnumerable<LoanApplicants> LoanApplicantsBetweenGivenDates(DateTime startDate,DateTime endDate)
    {
        Console.WriteLine("Inside LoanApplicantsBetweenGivenDates method in Cotroller....");
        IEnumerable<LoanApplicants> applicants = _svc.LoanApplicantsBetweenGivenDates(startDate,endDate);
        return applicants;
    }

    [HttpGet("status/{loanType}")]
     public IEnumerable<LoanApplicants> LoanApplicantsAccordingLoanStatus(string loanType)
    {
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus method in Cotroller....");
        IEnumerable<LoanApplicants> applicants = _svc.LoanApplicantsAccordingLoanStatus(loanType);
        return applicants;
    }

    [HttpGet("applicantAscustomer")]
      public List<LoanaplicantsInfo> GetAllapplicantInfo()
      {
        Console.WriteLine("Inside LoanaplicantsInfo method in Cotroller....");
        List<LoanaplicantsInfo> applicants = _svc.GetAllapplicantInfo();
        return applicants;
      }

}
