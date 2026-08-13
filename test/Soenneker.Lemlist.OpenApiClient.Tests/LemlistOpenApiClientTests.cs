using Soenneker.Tests.HostedUnit;

namespace Soenneker.Lemlist.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LemlistOpenApiClientTests : HostedUnitTest
{
    public LemlistOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
