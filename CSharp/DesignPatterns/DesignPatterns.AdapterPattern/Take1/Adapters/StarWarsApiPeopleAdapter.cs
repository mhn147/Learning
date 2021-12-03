using DesignPatterns.AdapterPattern.Models;
using DesignPatterns.AdapterPattern.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Adapters;

public class StarWarsApiPeopleCharacterSourceAdapter : ICharacterSourceAdapter
{
    private readonly StarWarsApi _starWarsApi;

    public StarWarsApiPeopleCharacterSourceAdapter(StarWarsApi starWarsApi)
    {
        _starWarsApi = starWarsApi;
    }

    public async Task<IEnumerable<Person>> GetCharacters()
    {
        return await _starWarsApi.GetCharacters();
    }
}
