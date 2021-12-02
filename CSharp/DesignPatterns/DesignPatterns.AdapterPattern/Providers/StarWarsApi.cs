using DesignPatterns.AdapterPattern.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Providers;

public class StarWarsApi
{
    public async Task<List<Person>> GetCharacters()
    {
        using (var client = new HttpClient())
        {
            var url = "https://swapi.dev/api/people";
            var result = await client.GetStringAsync(url);
            var people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;

            return people;
        }
    }
}
