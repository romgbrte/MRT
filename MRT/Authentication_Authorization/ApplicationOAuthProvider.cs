/*
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace MRT.Authentication_Authorization
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private const int AccessTokenDurationInDays = 14;

        public ApplicationOAuthProvider(string id)
        {
            _publicClientId = id ?? throw new ArgumentNullException(nameof(id));
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            ApplicationUserManager userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            Models.ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if(user == null)
            {
                context.SetError("invalid_grant", "Username or Password is incorrect");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(
                userManager, OAuthDefaults.AuthenticationType
            );
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(
                userManager, CookieAuthenticationDefaults.AuthenticationType
            );

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);

            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(KeyValuePair<string, string> property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if(context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string username)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>()
            {
                { "username", username }
            };
            return new AuthenticationProperties(properties);
        }

        public static int GetAccessTokenDurationInDays()
        {
            return AccessTokenDurationInDays;
        }
    }
}
*/