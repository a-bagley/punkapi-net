using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class Hop
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("amount")]
        public ValueUnit Amount { get; set; }

        [JsonPropertyName("add")]
        public string Add { get; set; }

        [JsonPropertyName("attribute")]
        public string Attribute { get; set; }
    }
}
