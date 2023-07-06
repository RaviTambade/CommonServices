namespace EntityLib;


public class Operation{
    public int OperationId{get;set;}
    public int AcctId{get;set;}
    public string AccountNumber{get;set;}
    public double Amount{get;set;}      //amount 
    public DateTime OperationTime{get;set;} // Time of operation
    public char OperationMode{get;set;}  //C or D
}