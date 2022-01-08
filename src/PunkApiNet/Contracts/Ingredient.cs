    using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class Ingredient
    {
        [JsonPropertyName("malt")]
        public IEnumerable<Malt> Malt { get; set; }

        [JsonPropertyName("hops")]
        public IEnumerable<Hop> Hops { get; set; }

        [JsonPropertyName("yeast")]
        public string Yeast { get; set; }
    }
}
