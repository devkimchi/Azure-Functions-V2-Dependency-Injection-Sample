//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//using FunctionsV2DiSample.FunctionApp.Configs;
//using FunctionsV2DiSample.FunctionApp.Functions.FunctionOptions;

//using Microsoft.Azure.WebJobs.Host;

//using Newtonsoft.Json;

//namespace FunctionsV2DiSample.FunctionApp.Functions
//{
//    /// <summary>
//    /// This represents the function entity for GitHub repositories.
//    /// </summary>
//    public class AutofacGitHubRepositoriesFunction : IFunction
//    {
//        private static MediaTypeWithQualityHeaderValue acceptHeader = new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json");
//        private static ProductInfoHeaderValue userAgentHeader = new ProductInfoHeaderValue("Mozilla", "5.0");

//        private readonly GitHub _github;
//        private readonly HttpClient _httpClient;

//        public AutofacGitHubRepositoriesFunction(GitHub github, HttpClient httpClient)
//        {
//            this._github = github;
//            this._httpClient = httpClient;
//        }

//        /// <inheritdoc />
//        public TraceWriter Log { get; set; }

//        /// <inheritdoc />
//        public async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options)
//        {
//            var option = options as GitHubRepositoriesHttpTriggerOptions;

//            string result;

//            this.AddRequestHeaders();

//            var requestUrl = $"{this._github.BaseUrl}{string.Format(this._github.Endpoints.Repositories, option.Type, option.Name)}";
//            using (var message = await this._httpClient.GetAsync(requestUrl).ConfigureAwait(false))
//            {
//                result = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
//            }

//            var res = JsonConvert.DeserializeObject<object>(result);

//            this.RemoveRequestHeaders();

//            return (TOutput)res;
//        }

//        private void AddRequestHeaders()
//        {
//            // https://gist.github.com/BellaCode/c0ba0a842bbe22c9215e
//            this._httpClient.DefaultRequestHeaders.Accept.Add(acceptHeader);
//            this._httpClient.DefaultRequestHeaders.UserAgent.Add(userAgentHeader);
//        }

//        private void RemoveRequestHeaders()
//        {
//            this._httpClient.DefaultRequestHeaders.Accept.Remove(acceptHeader);
//            this._httpClient.DefaultRequestHeaders.UserAgent.Remove(userAgentHeader);
//        }
//    }
//}