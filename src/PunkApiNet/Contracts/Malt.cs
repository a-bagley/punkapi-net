using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class Malt
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("amount")]
        public ValueUnit Amount { get; set; }
    }
}
