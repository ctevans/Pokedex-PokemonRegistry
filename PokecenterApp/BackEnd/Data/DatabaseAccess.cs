using BackEnd.Data.Models;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
/**
* Central Hub for getting particular models out of the DB.!--
* Trying to abstract this as far as I can away from ElasticSearch
* Really wanted to use the Repository Pattern but time unfortunately didn't make that possible :c
*/
namespace BackEnd.Data
{
    public class DatabaseAccess
    {
        private readonly ILogger<DatabaseAccess> _logger;
        ElasticSearchToModelMapper elasticSearchToModelMapper;

        public DatabaseAccess(ILogger<DatabaseAccess> logger, ElasticSearchToModelMapper elasticSearchToModelMapper)
        {
            this._logger = logger;
            this.elasticSearchToModelMapper = elasticSearchToModelMapper;
        }

        public async Task<List<Pokemon>> getPokemon(string name)
        {
            List<Pokemon> pokemon = null;
            try
            {
                pokemon = await Task.FromResult(elasticSearchToModelMapper.getListOfPokemon(name));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.ToString());
            }
            return pokemon;
        }

        public async Task<Pokemon> getPokemonById(int id)
        {
            Pokemon pokemon = null;
            try
            {
                pokemon = await Task.FromResult(elasticSearchToModelMapper.getSinglePokemonById(id));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.ToString());
            }
            return pokemon;
        }
    }
}