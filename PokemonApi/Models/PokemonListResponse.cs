using System.Text.Json.Serialization;

namespace PokemonApi.Models
{
    public class PokemonListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonListItem> Results { get; set; } = new();
    }

    public class PokemonListItem
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(Url)) return 0;
                var segments = Url.TrimEnd('/').Split('/');
                return int.TryParse(segments.LastOrDefault(), out int id) ? id : 0;
            }
        }

        public string ImageUrl => Id > 0
            ? $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png"
            : string.Empty;
    }

    public class PokemonListResult
    {
        public List<PokemonListItem> Items { get; set; } = new();
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => Offset > 0;
        public bool HasNextPage => Offset + Limit < TotalCount;
    }
}