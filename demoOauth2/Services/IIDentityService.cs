using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Services
{
    interface IIDentityService
    {
        Task<AuthenticationResult> LoginWithFacebookAsync(string accessToken);
        Task<AuthenticationResult> GenerateAuthenticationResultForUseAsync(IdentityUser user);
    }
}
