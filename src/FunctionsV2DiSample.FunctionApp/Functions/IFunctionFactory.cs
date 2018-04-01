using Microsoft.Azure.WebJobs.Host;

namespace FunctionsV2DiSample.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="CoreFunctionFactory"/> instance.
    /// </summary>
    public interface IFunctionFactory
    {
        /// <summary>
        /// Creates a function instance from the IoC container.
        /// </summary>
        /// <typeparam name="TFunction">Type of function.</typeparam>
        /// <param name="log"><see cref="TraceWriter"/> instance.</param>
        /// <param name="name">Instance name.</param>
        /// <returns>Returns the function instance.</returns>
        TFunction Create<TFunction>(TraceWriter log, string name = null) where TFunction : IFunction;
    }
}