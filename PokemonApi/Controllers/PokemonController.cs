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

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction(nameof(Index));
            }

            var pokemon = await _pokemonService.GetPokemonByNameOrIdAsync(id);

            if(pokemon == null)
            {
                ViewBag.ErrorMessage = $"Could not find Pokemon '{id}'. Please check your spelling or the id";
                return View("NotFound");
            }

            return View(pokemon);
        }

        
    }
}
