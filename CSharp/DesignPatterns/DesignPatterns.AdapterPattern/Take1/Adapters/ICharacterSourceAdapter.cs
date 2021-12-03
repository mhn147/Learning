using DesignPatterns.AdapterPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Adapters;

public interface ICharacterSourceAdapter
{
    Task<IEnumerable<Person>> GetCharacters();
}
