using PokemonApi.Models;
namespace PokemonApi.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResult> GetPokemonListAsync(int limit = 20, int offset = 0);

        Task<PokemonDetail?> GetPokemonByNameOrIdAsync(string nameOrId);
    }
}
