using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public class MashTemperature
    {
        [JsonPropertyName("temp")]
        public ValueUnit Temperature { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
    }
}
