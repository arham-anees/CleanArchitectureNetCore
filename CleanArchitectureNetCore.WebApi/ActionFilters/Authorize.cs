using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Linq;

namespace CleanArchitectureNetCore.WebApi.ActionFilters
{
  public class AuthorizeAttribute:Attribute, IAuthorizationFilter
  {
    public string Roles { get; set; }
    public AuthorizeAttribute(string roles)
    {
      Roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var user = context.HttpContext.User;
      if (!user.Identity.IsAuthenticated)
      {
        context.Result = new UnauthorizedResult();
        return;
      }

      if (string.IsNullOrEmpty(Roles))
      {
        return;
      }

      var roles = Roles.Split(',');
      if (roles.Any(r => user.IsInRole(r)))
      {
        return;
      }

      context.Result = new ForbidResult();
    }
  }
}
