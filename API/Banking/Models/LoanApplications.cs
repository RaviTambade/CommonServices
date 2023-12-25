namespace EntityLib
{
    public class LoanApplications
    {
        public int ApplicationId{ get; set; }  
        public DateOnly ApplicationDate{get;set;}
        public double LoanAmount{get;set;}
        public int LoanDuration{get;set;} 
        public string? LoanStatus{get;set;}        
        public int  AccountId {get; set;}
        public int  LoanTypeId {get; set;}  
         
           
    }


    public class LoanaplicationInfo : LoanApplications
    {
        public int CustomerUserId{get;set;}         
        public String ApplicantName{get;set;}
        public String ApplicantType{get;set;}
        public String LoanTypeName{get;set;}
    }
    
    /*public class LoanApplicationDetails : LoanApplications{
          public String LoanTypeName{get;set;}
    }*/
}