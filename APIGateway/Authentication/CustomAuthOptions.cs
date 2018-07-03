using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string CustomAuth = "CustomgAuth";
        public string Scheme => CustomAuth;
        public StringValues AuthKey { get; set; }
    }
}
