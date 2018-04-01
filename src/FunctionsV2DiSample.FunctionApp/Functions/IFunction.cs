using System.Threading.Tasks;

using FunctionsV2DiSample.FunctionApp.Functions.FunctionOptions;

using Microsoft.Azure.WebJobs.Host;

namespace FunctionsV2DiSample.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to functions.
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// Gets or sets the <see cref="TraceWriter"/> instance.
        /// </summary>
        TraceWriter Log { get; set; }

        /// <summary>
        /// Invokes the function.
        /// </summary>
        /// <typeparam name="TInput">Type of input.</typeparam>
        /// <typeparam name="TOutput">Type of output.</typeparam>
        /// <param name="input">Input instance.</param>
        /// <param name="options"><see cref="FunctionOptionsBase"/> instance.</param>
        /// <returns>Returns output instance.</returns>
        Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options);
    }
}