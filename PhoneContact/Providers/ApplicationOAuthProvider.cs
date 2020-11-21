#region 

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

#endregion

namespace PhoneContact.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private ApplicationSignInManager _applicationSignInManager;

        public ApplicationOAuthProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException(nameof(publicClientId));
        }

        public ApplicationSignInManager ApplicationSignInManager
        {
            get => _applicationSignInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _applicationSignInManager = value;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var result = await
                ApplicationSignInManager.PasswordSignInAsync(context.UserName, context.Password, false, false);

            switch (result)
            {
                case SignInStatus.Success:
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                        identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                        var authenticationTicket = new AuthenticationTicket(identity, CreateAuthProperties(context.UserName));

                        context.Validated(authenticationTicket);
                    }
                    break;
                case SignInStatus.LockedOut:
                    {
                    }
                    break;
                case SignInStatus.RequiresVerification:
                    {
                    }
                    break;
                case SignInStatus.Failure:
                    {
                        context.SetError("invalid_grant", "User name or password not correct!");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                var expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/");

                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateAuthProperties(string userName)
        {
            var data = new Dictionary<string, string>
            {
                {"userName", userName}
            };

            return new AuthenticationProperties(data);
        }
    }
}