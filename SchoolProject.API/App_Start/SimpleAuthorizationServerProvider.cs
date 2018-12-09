using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SchoolProject.Business.Services;
using SchoolProject.Data.Entities;

namespace SchoolProject.API.App_Start
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
    
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            ServiceProvider Services = new ServiceProvider();
            User result = Services.User.FirstOrDefault(x => x.Email == context.UserName && x.Password == context.Password);
            if (result != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", result.AccountType == 0 ? "student" : result.AccountType == 1 ? "teacher" : "admin"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Wrong email or password.");
            }

        }
    }
}
