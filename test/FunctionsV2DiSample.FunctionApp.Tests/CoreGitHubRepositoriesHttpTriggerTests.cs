using System.Threading.Tasks;

using FluentAssertions;

using FunctionsV2DiSample.FunctionApp.Functions;
using FunctionsV2DiSample.FunctionApp.Functions.FunctionOptions;
using FunctionsV2DiSample.FunctionApp.Tests.Fixtures;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace FunctionsV2DiSample.FunctionApp.Tests
{
    [TestClass]
    public class CoreGitHubRepositoriesHttpTriggerTests
    {
        [TestMethod]
        public async Task Given_TypeAndName_Run_Should_Return_Result()
        {
            var result = new { Hello = "World" };

            var function = new Mock<IGitHubRepositoriesFunction>();
            function.Setup(p => p.InvokeAsync<HttpRequest, object>(It.IsAny<HttpRequest>(), It.IsAny<FunctionOptionsBase>())).ReturnsAsync(result);

            var factory = new Mock<IFunctionFactory>();
            factory.Setup(p => p.Create<IGitHubRepositoriesFunction>(It.IsAny<TraceWriter>(), It.IsAny<string>())).Returns(function.Object);

            CoreGitHubRepositoriesHttpTrigger.Factory = factory.Object;

            var query = new FakeQueryCollection();
            query["type"] = "lorem";
            query["name"] = "ipsum";

            var req = new Mock<HttpRequest>();
            req.SetupGet(p => p.Query).Returns(query);

            var log = new TraceMonitor();
            var response = await CoreGitHubRepositoriesHttpTrigger.Run(req.Object, log).ConfigureAwait(false);

            response.Should().BeOfType<OkObjectResult>();
            (response as OkObjectResult).Value.Should().Be(result);
        }
    }
}