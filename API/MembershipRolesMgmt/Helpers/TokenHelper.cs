
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

public class TokenHelper{
    private  readonly IRoleService  _roleService;
    private IConfiguration _configuration;

    public TokenHelper(IConfiguration configuration,IRoleService roleService)
    {
        _configuration=configuration;
        _roleService=roleService;

    }

     private async Task<List<Claim>> GetAllClaims(User user)
    {
        List<Role> roles =  await _roleService.GetRoles(user.Id);
        List<Claim> claims = new List<Claim>
        {
            new Claim("contactNumber", user.ContactNumber),
            new Claim("userId", user.Id.ToString()),
        };

        foreach (var role in roles)
        {
            Claim claim =new Claim("roles", role.Name);
            claims.Add(claim);
        }
        return claims;
    }
    public async Task<string> GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWT:Secret"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await GetAllClaims(user)),
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