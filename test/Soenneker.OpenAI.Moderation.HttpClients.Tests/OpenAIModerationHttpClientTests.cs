using System.Net.Http;
using System.Threading.Tasks;
using AwesomeAssertions;
using Soenneker.OpenAI.Moderation.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenAI.Moderation.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenAIModerationHttpClientTests : HostedUnitTest
{
    private readonly IOpenAIModerationHttpClient _util;

    public OpenAIModerationHttpClientTests(Host host) : base(host)
    {
        _util = Resolve<IOpenAIModerationHttpClient>(true);
    }

    [Test]
    public async ValueTask Get_ConfiguresModerationEndpointAndApiKey()
    {
        HttpClient client = await _util.Get();

        client.BaseAddress.Should().Be("https://api.openai.com/v1");
        client.DefaultRequestHeaders.Authorization.Should().NotBeNull();
        client.DefaultRequestHeaders.Authorization!.Scheme.Should().Be("Bearer");
        client.DefaultRequestHeaders.Authorization.Parameter.Should().Be("test-key");
    }
}
