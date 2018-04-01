using Microsoft.Extensions.DependencyInjection;

namespace FunctionsV2DiSample.FunctionApp.Modules
{
    /// <summary>
    /// This represents the entity containing a list of dependencies.
    /// </summary>
    public class Module : IModule
    {
        /// <inheritdoc />
        public virtual void Load(IServiceCollection services)
        {
            return;
        }
    }
}