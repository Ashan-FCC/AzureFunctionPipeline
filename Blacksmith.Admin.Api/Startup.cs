using Blacksmith.Admin.Api;
using BlockchainLabs.Common;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Blacksmith.Admin.Api
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddJwtConfiguration();
        }
    }
}