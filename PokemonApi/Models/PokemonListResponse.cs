namespace PokemonApp.Models;

public class PokemonListResponse
{
    public int Count { get; set; }
    public List<PokemonListItem> Results { get; set; } = new();
}

public class PokemonListItem
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
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