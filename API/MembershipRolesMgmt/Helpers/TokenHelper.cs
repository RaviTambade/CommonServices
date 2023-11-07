
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public class TokenHelper{

  private  readonly IRoleRepository _roleRepository;
 private readonly JwtSettings _jwtSettings;


    public TokenHelper(IOptions<JwtSettings> jwtSettings,IRoleRepository  roleRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _roleRepository=roleRepository;
    }

 public async Task<string> GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
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



     private async Task<List<System.Security.Claims.Claim>> GetAllClaims(User user)
    {
        List<Role> roles =  await _roleRepository.GetRolesOfUser(user.Id);

        List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim("contactNumber", user.ContactNumber),
            new System.Security.Claims.Claim("userId", user.Id.ToString()),
        };

        foreach (var role in roles)
        {
            claims.Add(new System.Security.Claims.Claim("roles", role.Name));
        }

        return claims;
    }


}