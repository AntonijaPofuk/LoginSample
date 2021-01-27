using System.Security.Claims;
using System.Threading.Tasks;
using InfoNovitas.LoginSample.Authentication;
using Microsoft.Owin.Security.OAuth;

namespace InfoNovitas.LoginSample.Web.Api.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
 
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
 
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            MyUser user = null;
            using (AuthRepository _repo = new AuthRepository())
            {
                user = await _repo.FindUserAsync(context.UserName, context.Password);
 
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }
 
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("userId",user.Id.ToString()));
            context.Validated(identity);
 
        }
    }
}