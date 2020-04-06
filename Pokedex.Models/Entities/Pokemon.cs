using System;

namespace Pokedex.Models.Entities
{
    public class Pokemon
    {
        public Pokemon(string name, string url)
        {
            this.name = name;
            this.url = url;
            detail = @"Pokemon Details" + Environment.NewLine +
                "Name = " + this.name + Environment.NewLine +
                "Url = " + this.url;
        }

        public string name   { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
    }
}
