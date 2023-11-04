
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Transflower.MembershipRolesMgmt.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
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
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
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

                context.Items["contactNumber"] = contactNumber;

                 var userRoles = jwtToken.Claims.Where(x => x.Type == "roles").Select(c => c.Value).ToList();
                context.Items["userRoles"] = userRoles;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e);
            }
        }
    }
}