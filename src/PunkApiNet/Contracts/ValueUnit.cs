using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class ValueUnit
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
