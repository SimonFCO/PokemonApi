using Microsoft.AspNetCore.Http.HttpResults;
using PokemonApi.Models;
using PokemonApp.Models;
using System.Text.Json;

namespace PokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<PokemonListResult> GetPokemonListAsync(int limit = 20, int offset = 0)
        {
            try
            {
                var response = await _httpClient.GetAsync($"pokemon?limit={limit}&offset={offset}");

                if (!response.IsSuccessStatusCode)
                {
                    return new PokemonListResult
                    {
                        Items = new List<PokemonListItem>(),
                        Offset = offset,
                        Limit = limit,
                        TotalCount = 0
                    };
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<PokemonListResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return new PokemonListResult
                {
                    Items = result?.Results ?? new List<PokemonListItem>(),
                    Offset = offset,
                    Limit = limit,
                    TotalCount = result?.Count ?? 0
                };

            }
            catch (HttpRequestException)
            {
                return new PokemonListResult
                {
                    Items = new List<PokemonListItem>(),
                    Offset = offset,
                    Limit = limit,
                    TotalCount = 0
                };
            }
        }
    }
}
