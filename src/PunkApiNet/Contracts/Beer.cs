using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PunkApiNet.Contracts
{
    public partial class Beer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("first_brewed")]
        public string FirstBrewed { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("abv")]
        public double Abv { get; set; }

        [JsonPropertyName("ibu")]
        public double? Ibu { get; set; }

        [JsonPropertyName("target_fg")]
        public double? TargetFg { get; set; }

        [JsonPropertyName("target_og")]
        public double? TargetOg { get; set; }

        [JsonPropertyName("ebc")]
        public double? Ebc { get; set; }

        [JsonPropertyName("srm")]
        public double? Srm { get; set; }

        [JsonPropertyName("ph")]
        public double? Ph { get; set; }

        [JsonPropertyName("attenuation_level")]
        public double? AttenuationLevel { get; set; }

        [JsonPropertyName("volume")]
        public ValueUnit Volume { get; set; }

        [JsonPropertyName("boil_volume")]
        public ValueUnit BoilVolume { get; set; }

        [JsonPropertyName("method")]
        public Method Method { get; set; }

        [JsonPropertyName("ingredients")]
        public Ingredient Ingredients { get; set; }

        [JsonPropertyName("food_pairing")]
        public IEnumerable<string> FoodPairings { get; set; }

        [JsonPropertyName("brewers_tips")]
        public string BrewersTips { get; set; }

        [JsonPropertyName("contributed_by")]
        public string ContributedBy { get; set; }
    }
}
