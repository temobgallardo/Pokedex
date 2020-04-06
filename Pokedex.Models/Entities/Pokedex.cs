using System.Collections.Generic;

namespace Pokedex.Models.Entities
{
    public class Pokedex
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public IList<Pokemon> results { get; set; }
    }
}
