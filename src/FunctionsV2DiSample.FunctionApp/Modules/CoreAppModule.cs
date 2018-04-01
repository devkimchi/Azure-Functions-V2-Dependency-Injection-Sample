using System.IO;
using System.Net.Http;

using FunctionsV2DiSample.FunctionApp.Configs;
using FunctionsV2DiSample.FunctionApp.Extensions;
using FunctionsV2DiSample.FunctionApp.Functions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionsV2DiSample.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for dependencies.
    /// </summary>
    public class CoreAppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("config.json")
                             .Build();
            var github = config.Get<GitHub>("github");

            services.AddSingleton(github);
            services.AddSingleton<HttpClient>();
            services.AddTransient<IGitHubRepositoriesFunction, CoreGitHubRepositoriesFunction>();
        }
    }
}