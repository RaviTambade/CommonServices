namespace EntityLib;

public class Account
{
    //autoincrement id
    public int Id{ get; set; }
    public int CustomerId{get; set;}   
    public string? AcctNumber{ get; set; }
    public string? AcctType{get;set;}
    public string? IFSCCode{ get; set; }
    public DateTime RegisterationDate{ get; set; }
    public double Balance {get;set;}
}

