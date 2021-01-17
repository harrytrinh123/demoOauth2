using demoOauth2.External.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Services
{
    interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidationAccessTokenAsync(string accessToken);

        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
