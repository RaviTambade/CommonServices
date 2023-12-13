using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;
using Banking.Helpers;

namespace BankingServices.Controllers;

[ApiController]
[Route("/api/applicant")]
public class LoanApplicantController : ControllerBase
{
    private readonly ILoanApplicantService _svc;
    private readonly HttpClient _httpClient;
    
    public LoanApplicantController(ILoanApplicantService svc,IHttpClientFactory httpClient)
    {
        Console.WriteLine("Ctr is called......");
        _svc = svc;
        
        _httpClient = httpClient.CreateClient();

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


    [HttpPut]
     [Route("{id}")]
    public async Task <bool> Update(LoanaplicantsInfo applicant)
    {
         Console.WriteLine("Inside Update method ......");
        Console.WriteLine("Status CONTROLLER : " + applicant.Status);
        
        bool status = await _svc.Update(applicant);
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
    /*public LoanApplicants GetById(int id)
    {
        LoanApplicants applicant = _svc.GetById(id);
        return applicant;
    }*/

    public async Task <LoanaplicantsInfo> GetById(int id)
    {

        Console.WriteLine("Inside GetById method in Cotroller....");

         LoanaplicantsInfo applicant = await _svc.GetById(id);
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        //LoanaplicantsInfo DetailsOfApplicant =  await helper.applicantDetailsById(applicant);
        List<LoanaplicantsInfo> applicants = new List<LoanaplicantsInfo>(){applicant};

        List<LoanaplicantsInfo> DetailsOfApplicants =  await helper.applicantsDetails(applicants);
        
        
        return DetailsOfApplicants[0];


        //LoanaplicantsInfo applicant = await _svc.GetById(id);
        //return applicant;
    }
    [HttpGet("{startDate}/{endDate}")]
     public IEnumerable<LoanApplicants> LoanApplicantsBetweenGivenDates(DateTime startDate,DateTime endDate)
    {
        Console.WriteLine("Inside LoanApplicantsBetweenGivenDates method in Cotroller....");
        IEnumerable<LoanApplicants> applicants = _svc.LoanApplicantsBetweenGivenDates(startDate,endDate);


        return applicants;
    }

    [HttpGet("status/{loanType}")]
     public async Task<List<LoanaplicantsInfo>> LoanApplicantsAccordingLoanStatus(string loanType)
    {
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus method in Cotroller....");
         List<LoanaplicantsInfo> applicants = await _svc.LoanApplicantsAccordingLoanStatus(loanType);
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        List<LoanaplicantsInfo> DetailsOfApplicants =  await helper.applicantsDetails(applicants);
        
        return DetailsOfApplicants;
    }

    [HttpGet("applicantAscustomer")]
      public async Task<List<LoanaplicantsInfo>> GetAllapplicantInfo()
      {
        Console.WriteLine("Inside LoanaplicantsInfo method in Cotroller....");
        List<LoanaplicantsInfo> applicants = await _svc.GetAllapplicantInfo();
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        List<LoanaplicantsInfo> DetailsOfApplicants =  await helper.applicantsDetails(applicants);
        
        return DetailsOfApplicants;
      }

      /* These functions are written in Helper class
    public async Task<List<User>> GetUserDetails(string userIds)
    {
        var response = await _httpClient.GetFromJsonAsync<List<User>>(
            $"http://localhost:5142/api/users/name/{userIds}"
        );
        return response;
    }

    public async Task<List<CorporateUser>> GetCorporateUserDetails(string userIds)
    {
        var response = await _httpClient.GetFromJsonAsync<List<CorporateUser>>(
            $" http://localhost:5041/api/corporates/names/{userIds}"
        );
        return response;
    }*/

}
