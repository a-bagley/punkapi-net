using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class Method
    {
        [JsonPropertyName("mash_temp")]
        public IEnumerable<MashTemperature> MashTemp { get; set; }

        public Fermentation Fermentation { get; set; }

        [JsonPropertyName("twist")]
        public string Twist { get; set; }
    }
}
