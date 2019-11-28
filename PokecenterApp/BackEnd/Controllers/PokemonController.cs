using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackEnd.Data.Models;
using Nest;
using BackEnd.Services;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly PokemonService pokemonService;

        public PokemonController(ILogger<PokemonController> logger, PokemonService pokemonService)
        {
            _logger = logger;
            this.pokemonService = pokemonService;
        }

        [HttpGet("name={name}")]
        public async Task<List<Pokemon>> GetSearchResultsByName(string name)
        {
            _logger.LogInformation("[ {Time} ] GetSearchResultsByName invoked on api/pokemon " +
            "with name parameter {name}.", DateTime.UtcNow, name);

            return await pokemonService.getPokemon(name);
        }

        [HttpGet("id={id}")]
        public async Task<Pokemon> GetOnePokemonById(int id)
        {
            _logger.LogInformation("[ {Time} ] GetOnePokemonById invoked on api/pokemon " +
            "with id parameter {id}.", DateTime.UtcNow, id);

            return await pokemonService.getPokemonById(id);
        }
    }
}

