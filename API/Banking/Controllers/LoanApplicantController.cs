using Microsoft.AspNetCore.Mvc;
using ServicesLib;
using EntityLib;


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
      public async Task<List<LoanaplicantsInfo>> GetAllapplicantInfo()
      {
        Console.WriteLine("Inside LoanaplicantsInfo method in Cotroller....");
        List<LoanaplicantsInfo> applicants = await _svc.GetAllapplicantInfo();

        String user_ids = string.Join(',',applicants.Select(applicant => applicant.CustomerUserId  ).ToList());
        Console.WriteLine(user_ids);
        List<User> users =  await GetUserDetails(user_ids);
        foreach(var applicant in applicants)
        {
            User user = users.FirstOrDefault(u => u.Id == applicant.CustomerUserId);
            if(user!=null)
            {
                applicant.ApplicantName = user.FirstName + " " + user.LastName;
            }
        }
        return applicants;
      }

      
    public async Task<List<User>> GetUserDetails(string userIds)
    {
        var response = await _httpClient.GetFromJsonAsync<List<User>>(
            $"http://localhost:5142/api/users/name/{userIds}"
        );
        return response;
    }
}
