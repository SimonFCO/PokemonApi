using Microsoft.AspNetCore.Mvc;
using PokemonApi.Services;

namespace PokemonApi.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index(int limit = 20, int offset = 0)
        {
            var result = await _pokemonService.GetPokemonListAsync(limit, offset);

            return View(result);
        }
    }
}
