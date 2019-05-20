using Amazon.Lambda.ApplicationLoadBalancerEvents;
using Amazon.Lambda.Core;
using AWSServerless3;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class WhenStartingApplicationLoadBalancingFunction
    {
        [Test]
        public async Task ShouldStart()
        {

            var fileName = "test";
            ILambdaContext context = null;
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = @"{""Path"": ""/Test/Index"",
    ""HttpMethod"": ""GET"",
    ""Headers"": {
        ""accept"": ""text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3"",
        ""accept-encoding"": ""gzip, deflate, br"",
        ""accept-language"": ""en-US,en;q=0.9"",
    },
    ""QueryStringParameters"": {},
    ""MultiValueQueryStringParameters"": null,
    ""Body"": """",
    ""IsBase64Encoded"": true
}";

            var request = JsonConvert.DeserializeObject<ApplicationLoadBalancerRequest>(requestStr);

            var response = await lambdaFunction.FunctionHandlerAsync(request, context);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        //https://github.com/aws/aws-lambda-dotnet/blob/a05c1f3705be8478c2a86a2c8741f06bf7bd7063/Libraries/src/Amazon.Lambda.AspNetCoreServer/AbstractAspNetCoreFunction.cs#L147

        //https://github.com/aspnet/AspNetCore/blob/9355c7c1a5bba8c745212ff1a0a768c976b20fc8/src/DefaultBuilder/src/WebHost.cs#L149
    }
}