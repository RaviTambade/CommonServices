using System.ComponentModel.DataAnnotations;

namespace Transflower.MembershipRolesMgmt.Helpers;

public class AppSettings
{
    [Required]
    public required string Secret { get; init; }
}
