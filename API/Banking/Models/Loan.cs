namespace EntityLib
{
    public class Loan
    {
        public int LoanId{ get; set; }        
        public double Amount{ get; set; }
        public DateTime LoanSanctionDate{get;set;}
        public int Duration {get; set;}
        public double IntrestRate{get; set;}
        public int AccountId{get;set;}
        
    }
}