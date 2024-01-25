using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace  Transflower.MembershipRolesMgmt.Helpers;
public class TokenHelper
{
    private readonly IRoleService _roleService;
    private readonly IConfiguration _configuration;

    public TokenHelper(IConfiguration configuration, IRoleService roleService)
    {
        _configuration = configuration;
        _roleService = roleService;
    }

    private async Task<List<Claim>> GetAllClaims(User user, string lob)
    {
        List<Role> roles = await _roleService.GetRoles(user.Id, lob);
        List<Claim> claims = new List<Claim>
        {
            new Claim("contactNumber", user.ContactNumber),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.FirstName)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
        return claims;
    }

    public async Task<string> GenerateJwtToken(User user, string lob)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(
            _configuration.GetValue<string>("JWT:Secret")
        );
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await GetAllClaims(user, lob)),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
