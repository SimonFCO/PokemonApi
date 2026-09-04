using PokemonApi.Models;
using PokemonApp.Models;
namespace PokemonApi.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonListItem>> GetPokemonListsAsync(int limit = 20, int offset = 0);
    }
}
