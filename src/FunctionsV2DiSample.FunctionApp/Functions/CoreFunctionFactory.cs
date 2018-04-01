using System;

using FunctionsV2DiSample.FunctionApp.Containers;
using FunctionsV2DiSample.FunctionApp.Modules;

using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionsV2DiSample.FunctionApp.Functions
{
    /// <summary>
    /// This represents the factory entity for functions.
    /// </summary>
    public class CoreFunctionFactory : IFunctionFactory
    {
        private readonly IServiceProvider _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreFunctionFactory"/> class.
        /// </summary>
        /// <param name="module"><see cref="IModule"/> instance.</param>
        public CoreFunctionFactory(IModule module = null)
        {
            this._container = new ContainerBuilder()
                                  .RegisterModule(module)
                                  .Build();
        }

        /// <inheritdoc />
        public TFunction Create<TFunction>(TraceWriter log, string name = null)
            where TFunction : IFunction
        {
            // Resolve the function instance directly from the container.
            var function = this._container.GetService<TFunction>();
            function.Log = log;

            return function;
        }
    }
}