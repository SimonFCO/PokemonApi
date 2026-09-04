using PokemonApi.Models;
using PokemonApp.Models;
namespace PokemonApi.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResult> GetPokemonListAsync(int limit = 20, int offset = 0);
    }
}
