namespace EntityLib
{
    public class Loan
    {
        public int LoanId{ get; set; }        
        public DateOnly LoanSanctionDate{get;set;}
        public int EMIDay {get; set;}
        public double EMIAmount{ get; set; }
        public int ApplicationId{get;set;}
        
    }
}