namespace Transflower.MembershipRolesMgmt.Models.Requests;
{
    public class AuthenticateRequest
    {
        public string? ContactNumber { get; set; }
        public string? Password { get; set; }
    }
}