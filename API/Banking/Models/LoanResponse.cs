namespace EntityLib
{
    public class LoanResponse
    {
        LoanApplications  TheApplication{get;set;} //Containment
        LoanapplicationInfo TheApplicant{get;set;}
        
    }
}