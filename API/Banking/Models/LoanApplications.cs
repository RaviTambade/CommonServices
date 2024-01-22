namespace EntityLib
{
    public class LoanApplications //LoanApplication change it
    {
        public int ApplicationId{ get; set; }  
        public DateOnly ApplicationDate{get;set;}
        public double LoanAmount{get;set;}
        public int LoanDuration{get;set;} 
        public string? LoanStatus{get;set;}        
        public int  AccountId {get; set;}
        public int  LoanTypeId {get; set;}  
         
           
    }
}