using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace PractiseApp.Models
{
    public class AppAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            //return base.ValidateClientAuthentication(context);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using(StudAuth stud = new StudAuth())
            {
                var _stud = stud.ValidateStud(context.UserName , context.Password);
                if(_stud == null)
                {
                    context.SetError("Invalid Grant", "Email or Password is incorrect");
                }

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, _stud.Username));
                    identity.AddClaim(new Claim(ClaimTypes.Email, _stud.Email));
                context.Validated(identity);
                
            }
            //return base.GrantResourceOwnerCredentials(context);
        }
    }
}