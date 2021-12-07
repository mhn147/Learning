using System.Threading.Tasks;
using DesignPatterns.AdapterPattern.Adapters;
using DesignPatterns.AdapterPattern.Providers;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.AdapterPattern.Tests;

public class TestRunner
{
    private readonly ITestOutputHelper _output;

    public TestRunner(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task DisplayCharactersFromFile()
    {
        var fileName = @"./People.json";

        var service = new StarWarsCharacterDisplayService(
            new CharacterFileSourceAdapter(fileName, new CharacterFileSource()));

        var result = await service.ListCharacters();

        _output.WriteLine(result);
    }

    [Fact]
    public async Task DisplayCharactersFromApi()
    {
        var service = new StarWarsCharacterDisplayService(
            new StarWarsApiPeopleCharacterSourceAdapter(new StarWarsApi()));

        var result = await service.ListCharacters();

        _output.WriteLine(result);
    }
}