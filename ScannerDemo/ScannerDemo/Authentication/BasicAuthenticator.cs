using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

/***
 * Source: http://lbadri.wordpress.com/2014/02/13/basic-authentication-with-asp-net-web-api-using-authentication-filter/
 ***/

namespace ScannerDemo.Authentication
{
    public class BasicAuthenticator : Attribute, IAuthenticationFilter
    {
        private readonly string realm;
        public bool AllowMultiple { get { return false; } }

        public BasicAuthenticator(string realm)
        {
            this.realm = "realm=" + realm;
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context,
                                      CancellationToken cancellationToken)
        {
            var req = context.Request;
            if (req.Headers.Authorization != null &&
                    req.Headers.Authorization.Scheme.Equals(
                              "basic", StringComparison.OrdinalIgnoreCase))
            {
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string credentials = encoding.GetString(
                                      Convert.FromBase64String(
                                          req.Headers.Authorization
                                                       .Parameter));
                string[] parts = credentials.Split(':');
                string userId = parts[0].Trim();
                string password = parts[1].Trim();

                // Quick 'n Dirty: Set User&Password in Scanner Controller
                Models.User usr = new Models.User();
                usr.Username = userId;
                usr.Password = password;
                Controllers.ScannerController.usr = usr;
                
                if (userId.Equals(password)) // Just a dumb check
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, "demo")
                    };
                    var id = new ClaimsIdentity(claims, "Basic");
                    var principal = new ClaimsPrincipal(new[] { id });
                    context.Principal = principal;
                }
                else
                {
                    context.ErrorResult = new UnauthorizedResult(
                         new AuthenticationHeaderValue[0],
                                              context.Request);
                }
            }
            else
            {
                context.ErrorResult = new UnauthorizedResult(
                         new AuthenticationHeaderValue[0],
                                              context.Request);
            }

            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                      CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result, realm);
            return Task.FromResult(0);
        }
    }
}