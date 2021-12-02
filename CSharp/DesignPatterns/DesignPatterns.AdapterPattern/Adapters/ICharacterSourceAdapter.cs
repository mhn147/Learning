using DesignPatterns.AdapterPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AdapterPattern.Adapters;

public interface ICharacterSourceAdapter
{
    Task<IEnumerable<Person>> GetCharacters();
}
