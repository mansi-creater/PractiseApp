   using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PractiseApp.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized, "You are not authorised");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] useremailpassword = decodeAuthToken.Split(':');

                string useremail = useremailpassword[0];
                string userpassword = useremailpassword[1];

                if(ValidateUser.Login(useremail, userpassword))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(useremail), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Fail");
                }
            }
            //base.OnAuthorization(actionContext);
        }
    }
}