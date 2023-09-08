namespace EntityLib
{
    public class Installment
    {
        public int InstallmentId{ get; set; }
        public DateTime InstallmentDate{ get; set; }
        public double Amount{ get; set; }
        public int LoanOrderId{ get; set; }
    }
}