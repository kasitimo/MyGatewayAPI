using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace APIGateway.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        private const string AuthorizationHeaderName = "Authorization";
        private const string BasicSchemeName = "CustomAuth";
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Get Authorization header value
            if (!AuthenticationHeaderValue.TryParse(Request.Headers[AuthorizationHeaderName], out AuthenticationHeaderValue headerValue))
            {
                //Invalid Authorization header
                return Task.FromResult(AuthenticateResult.Fail("Cannot read authorization header."));
            }
            var header = headerValue.Scheme;
            var valueh = headerValue.Parameter;

            if (!BasicSchemeName.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                //Not Basic authentication header
                return Task.FromResult(AuthenticateResult.Fail("Cannot read authorization sehema."));
            }

            var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
