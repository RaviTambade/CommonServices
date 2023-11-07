namespace Transflower.MembershipRolesMgmt.Models.Entities;

public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Area { get; set; }
    public required string LandMark { get; set; }
    public string? City { get; set; }
    public required string State { get; set; }
    public string? UserAnotherContactNumber { get; set; }
    public required string PinCode { get; set; }
}
