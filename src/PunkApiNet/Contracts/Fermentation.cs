using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class Fermentation
    {
        [JsonPropertyName("temp")]
        public ValueUnit Temp { get; set; }
    }
}
