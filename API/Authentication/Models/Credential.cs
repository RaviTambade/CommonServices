namespace AuthenticationAPI.Models;

public class Credential
{
    public int Id { get; set; }
    public string? ContactNumber { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
