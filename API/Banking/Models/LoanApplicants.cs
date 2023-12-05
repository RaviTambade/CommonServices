namespace EntityLib
{
    public class LoanApplicants
    {
        public int ApplicantId{ get; set; }  
        public int AccountId{get;set;}  
        public DateOnly ApplyDate{get;set;}
        public string? PanId {get; set;}
        public string? LoanType {get; set;}
        public double Amount{get;set;}
        public string? Status{get;set;}
            
    }
}