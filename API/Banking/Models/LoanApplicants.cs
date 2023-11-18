namespace EntityLib
{
    public class LoanApplicants
    {
        public int ApplicantId{ get; set; }  
        public int AccountId{get;set;}  
        public string? FirstName{get;set;}   
        public string? MiddleName{get;set;} 
        public string? LastName{get;set;}
        public DateOnly BirthDate{get; set;}
        public string? Gender{get;set;}
        public string? ContactNumber {get; set;}      
        public string? Email {get; set;}
        public string? Address {get; set;}
        public string? AdharId {get; set;}
        public string? PanId {get; set;}
        public string? LoanType {get; set;}
        public double Amount{get;set;}
        public string Status{get;set;}
            
    }
}