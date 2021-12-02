using DesignPatterns.AdapterPattern.Adapters;
using DesignPatterns.AdapterPattern.Enums;
using DesignPatterns.AdapterPattern.Models;
using DesignPatterns.AdapterPattern.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter _characterSourceAdapter;

        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSourceAdapter)
        {
            _characterSourceAdapter = characterSourceAdapter;
        }

        // This method is the client
        public async Task<string> ListCharacters()
        {
            var people = await _characterSourceAdapter.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");
            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
