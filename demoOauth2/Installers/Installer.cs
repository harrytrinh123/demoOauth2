using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOauth2.Installers
{
    interface Installer
    {
        void InstallerService(IServiceCollection services, IConfiguration configuration);
    }
}
