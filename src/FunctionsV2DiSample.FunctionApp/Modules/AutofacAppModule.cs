//using System.IO;
//using System.Net.Http;

//using Autofac;

//using FunctionsV2DiSample.FunctionApp.Configs;
//using FunctionsV2DiSample.FunctionApp.Extensions;
//using FunctionsV2DiSample.FunctionApp.Functions;

//using Microsoft.Extensions.Configuration;

//namespace FunctionsV2DiSample.FunctionApp.Modules
//{
//    public class AutofacAppModule : Autofac.Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            var config = new ConfigurationBuilder()
//                             .SetBasePath(Directory.GetCurrentDirectory())
//                             .AddJsonFile("config.json")
//                             .Build();
//            var github = config.Get<GitHub>("github");
//            builder.RegisterInstance(github).As<GitHub>().SingleInstance();

//            var httpClient = new HttpClient();
//            builder.RegisterInstance(httpClient).As<HttpClient>().SingleInstance();

//            builder.RegisterType<AutofacGitHubRepositoriesFunction>().Named<IFunction>("github").InstancePerLifetimeScope();
//        }
//    }
//}
