using System.Net;
using CIoTD.Core.V1.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CIoTD.Api.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User)context.HttpContext.Items["User"];

        if (user == null)
            context.Result = new JsonResult(new { message = "Não Autorizado" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}
