using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net;

namespace ElectionCommission.Authorization
{

    public class OfficialAuthorization : Attribute, IAuthorizationFilter
    {
    

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //check access 
            try
            {
                var headers = context.HttpContext.Request.Headers.ToDictionary();
                headers.TryGetValue("secret-key", out var secretValue);

                if (secretValue.ToString().Equals("ABCD"))
                {
                    return;
                }
                else
                {
                    //DENIED!
                    //return "ChallengeResult" to redirect to login page (for example)
                    context.Result = new ContentResult { StatusCode = (int?)HttpStatusCode.Forbidden };
                }
            }
            catch (Exception ex)
            {

                context.Result = new ForbidResult();
            }
        }
    }
}