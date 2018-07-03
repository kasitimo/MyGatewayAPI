using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Authentication
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, string authenticationScheme, Action<CustomAuthOptions> configureOptions)
        {
            // Add custom authentication scheme with custom options and custom handler
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>(authenticationScheme, configureOptions);
        }
    }
}
