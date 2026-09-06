using Microsoft.AspNetCore.Http.HttpResults;
using PokemonApi.Models;
using System.Net;
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

        public async Task<PokemonDetail?> GetPokemonByNameOrIdAsync(string nameOrId)
        {
            if (string.IsNullOrWhiteSpace(nameOrId))
            {
                return null;
            }

            try
            {
                var cleanInput = nameOrId.Trim().ToLower();

                var response = await _httpClient.GetAsync($"pokemon/{cleanInput}");

                if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PokemonDetail>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
