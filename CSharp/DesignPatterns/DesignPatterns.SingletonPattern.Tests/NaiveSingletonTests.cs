using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.SingletonPattern.Tests;

public class NaiveSingletonTests
{
    private readonly ITestOutputHelper _output;

    public NaiveSingletonTests(ITestOutputHelper output)
    {
        _output = output;
        
    }
    
    [Fact]
    public void ReturnsNonNullSingletonInstance()
    {
        var result = NaiveSingleton.Instance;
        
        Assert.NotNull(result);
        Assert.IsType<NaiveSingleton>(result);
    }
}