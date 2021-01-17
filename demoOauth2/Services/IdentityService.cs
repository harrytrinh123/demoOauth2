using demoOauth2.Responses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Services
{
    public class IdentityService : IIDentityService
    {
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly UserManager<IdentityUser> _userManager;
        public IdentityService(FacebookAuthService facebookAuthService, UserManager userManager)
        {
            _facebookAuthService = facebookAuthService;
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> GenerateAuthenticationResultForUseAsync(IdentityUser user)
        {
            //var res;
            //res = await new AuthSuccessResponse
            //{
            //    Token = "asd",
            //    RefreshToken = "asdsad"
            //};
            //return res;
        }

        public async Task<AuthenticationResult> LoginWithFacebookAsync(string accessToken)
        {
            var validatedToken = await _facebookAuthService.ValidationAccessTokenAsync(accessToken);
            if(!validatedToken.Data.IsValid)
            {
                
            }

            var userInfo = await _facebookAuthService.GetUserInfoAsync(accessToken);
            var user = await _userManager.FindByEmailAsync(userInfo.Email);

            if(user == null)
            {
                var identityUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userInfo.Email,
                    UserName = userInfo.Email
                };
                var createdUser = await _userManager.CreateAsync(identityUser);
                if(!createdUser.Succeeded)
                {
                    
                }

                return await GenerateAuthenticationResultForUseAsync(user);
            }
            return await GenerateAuthenticationResultForUseAsync(user);
        }

        
    }
}
