using demoOauth2.Requests.Queries;
using demoOauth2.Responses;
using demoOauth2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService; 
        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] UserFacebookAuthRequest request)
        {
            var authResponse = await _identityService.LoginWithFacebookAsync(request.AcccessToken);
            if(!authResponse.Success)
            {
                return BadRequest();
            }
            return Oke(new AuthSuccessResponse { 
                Token = authResponse
            });
        }
    }
}
