using demoOauth2.Options;
using demoOauth2.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Installers
{
    public class FacebookAuthInstaller : Installer
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            var facebookAuthSettings = new FacebookAuthSettings;
            configuration.Bind(nameof(FacebookAuthSettings), facebookAuthSettings);

            services.AddSingleton(facebookAuthSettings);

            services.AddHttpClient();
            services.AddSingleton<IFacebookAuthService, FacebookAuthService>();  
        }
    }
}
