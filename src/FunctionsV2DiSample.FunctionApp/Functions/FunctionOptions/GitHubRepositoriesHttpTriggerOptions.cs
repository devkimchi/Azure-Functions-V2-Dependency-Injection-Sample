using Microsoft.AspNetCore.Http;

namespace FunctionsV2DiSample.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the options entity for the <see cref="CoreGitHubRepositoriesHttpTrigger"/> class.
    /// </summary>
    public class GitHubRepositoriesHttpTriggerOptions : FunctionOptionsBase
    {
        private readonly HttpRequest _req;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubRepositoriesHttpTriggerOptions"/> class.
        /// </summary>
        /// <param name="req"></param>
        public GitHubRepositoriesHttpTriggerOptions(HttpRequest req)
        {
            this._req = req;
        }

        /// <summary>
        /// Gets the repository type - users or organisations.
        /// </summary>
        public string Type => this.GetRepositoryType();

        /// <summary>
        /// Gets the repository name.
        /// </summary>
        public string Name => this.GetRepositoryName();

        private string GetRepositoryType()
        {
            var type = this._req.Query["type"];

            return type;
        }

        private string GetRepositoryName()
        {
            var name = this._req.Query["name"];

            return name;
        }
    }
}