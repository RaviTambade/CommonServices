namespace AuthenticationAPI.Models;

public class ChangePassword
{
    public string ContactNumber { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

}
