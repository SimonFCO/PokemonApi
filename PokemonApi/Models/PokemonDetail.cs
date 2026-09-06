using System.Text.Json.Serialization;

namespace PokemonApi.Models
{
    public class PokemonDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites Sprites { get; set; } = new();

        [JsonPropertyName("types")]
        public List<PokemonTypeSlot> Types { get; set; } = new();

        [JsonPropertyName("stats")]
        public List<PokemonStatSlot> Stats { get; set; } = new();
    }

    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }
    }

    public class PokemonTypeSlot
    {
        [JsonPropertyName("type")]
        public ApiReference Type { get; set; } = new();
    }

    public class PokemonStatSlot
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("stat")]
        public ApiReference Stat { get; set; } = new();
    }

    public class ApiReference
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
