using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Transflower.MembershipRolesMgmt.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string? Roles { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (this.Roles is null)
            {
                return;
            }

            var userRoles = (List<string>?)context.HttpContext.Items["userRoles"];
            bool status = false;

            if (userRoles is not null)
            {
                List<string> requiredRoles = this.Roles.Split(',').ToList();
                bool result = requiredRoles.Intersect(userRoles).Count() >= 1;
                if (result)
                {
                    status = true;
                }
            }

            if (status == false )
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
