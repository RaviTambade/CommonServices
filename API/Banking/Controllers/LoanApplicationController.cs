using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;
using Banking.Helpers;

namespace BankingServices.Controllers;

[ApiController]
[Route("/api/loanapplications")]
public class LoanApplicationController : ControllerBase
{
    private readonly ILoanApplicationsService _svc;
    private readonly HttpClient _httpClient;
    
    public LoanApplicationController(ILoanApplicationsService svc,IHttpClientFactory httpClient)
    {
        Console.WriteLine("Ctr is called......");
        _svc = svc;
        
        _httpClient = httpClient.CreateClient();

    }

    [HttpGet]

    public IEnumerable<LoanApplications> GetAll()
    {
        Console.WriteLine("Inside getall method....");
        IEnumerable<LoanApplications> applications = _svc.GetAll();
        return applications;
    }

    [HttpPost]
    public bool Insert(LoanApplications application)
    {
        // Console.WriteLine("Inside Insert method ......");
        // Console.WriteLine("Amount CONTROLLER : " + application.Amount);
        // Console.WriteLine("Account ID In Repo:- " + application.AccountId);
        // Console.WriteLine("ApplayDate In Repo:- " + application.ApplyDate);
        // Console.WriteLine("LoanType In Repo:- " + application.LoanType);
        // Console.WriteLine("PanId In Repo:- " + application.PanId);

        bool status = _svc.Insert(application);
        return status;
    }


    [HttpPut]
     [Route("{id}")]
    public async Task <bool> Update(LoanApplications application)
    {
         Console.WriteLine("Inside Update method ......");
        Console.WriteLine("Status CONTROLLER : " + application.LoanStatus);
        
        bool status = await _svc.UpdateStatus(application);
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
   
    public async Task <LoanResponse> GetById(int id)
    {

        Console.WriteLine("Inside GetById method in Cotroller....");

        LoanResponse application = await _svc.GetById(id);
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        //LoanaplicantsInfo DetailsOfApplicant =  await helper.applicantDetailsById(applicant);
        List<LoanResponse> applications = new List<LoanResponse>(){application};

        List<LoanResponse> DetailsOfApplicants =  await helper.applicationsDetails(applications);
        
        
        return DetailsOfApplicants[0];


        //LoanaplicantsInfo applicant = await _svc.GetById(id);
        //return applicant;
    }
    [HttpGet("from/{startdate}/to/{enddate}")]

     public async Task<IEnumerable<LoanResponse>> GetallLoans(DateTime startDate,DateTime endDate)
    {
        // Console.WriteLine("Inside LoanApplicantsBetweenGivenDates method in Cotroller....");
        // IEnumerable<LoanApplications> applicants = _svc.LoanApplicationBetweenGivenDates(startDate,endDate);
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus method in Cotroller....");
        List<LoanResponse> applications = await _svc.GetAllLoans(startDate,endDate);
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        List<LoanResponse> DetailsOfApplicants =  await helper.applicationsDetails(applications);
        
        return DetailsOfApplicants;

       
    }

    [HttpGet("status/{loanType}")]

    //GetallLoans
     public async Task<List<LoanResponse>> GetallLoans(string loanType)
    {
        Console.WriteLine("Inside LoanApplicantsAccordingLoanStatus method in Cotroller....");
         List<LoanResponse> applications = await _svc.GetAllLoans(loanType);
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        List<LoanResponse> DetailsOfApplicants =  await helper.applicationsDetails(applications);
        
        return DetailsOfApplicants;
    }

    [HttpGet("applicationAscustomer")]
      public async Task<List<LoanResponse>> GetAllapplicantsInfo()
      {
        Console.WriteLine("Inside LoanaplicantsInfo method in Cotroller....");
        List<LoanResponse> applicants = await _svc.GetAllapplicantsInfo();
        LoanApplicationHelper helper = new LoanApplicationHelper(_httpClient);
        List<LoanResponse> DetailsOfApplicants =  await helper.applicationsDetails(applicants);
        
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
