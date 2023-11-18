
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Transflower.MembershipRolesMgmt.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _JwtSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<JwtSettings> JwtSettings)
        {
            _next = next;
            _JwtSettings = JwtSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                AttachUserToContext(context, token);
            await _next(context);
        }

        private void AttachUserToContext(HttpContext context,  string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_JwtSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var contactNumber=jwtToken.Claims.First(x => x.Type == "contactNumber").Value;
                var userId=jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var userRoles = jwtToken.Claims.Where(x => x.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

                context.Items["userId"] = userId;
                context.Items["contactNumber"] = contactNumber;
                context.Items["userRoles"] = userRoles;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e);
            }
        }
    }
}