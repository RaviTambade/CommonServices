namespace EntityLib
{
    public class LoanResponse
    {
        public LoanApplications  TheApplication{get;set;} //Containment
        public LoanapplicationInfo TheApplicant{get;set;}
        
    }
}