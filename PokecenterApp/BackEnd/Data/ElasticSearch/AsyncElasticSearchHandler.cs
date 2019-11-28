using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Data.DTO;
using Nest;
using Microsoft.Extensions.Logging;
using System;

namespace BackEnd.Data.ElasticSearch
{
    public class AsyncElasticSearchHandler
    {
        private readonly ILogger<AsyncElasticSearchHandler> _logger;
        private readonly ElasticClient elasticClient;

        public AsyncElasticSearchHandler(ILogger<AsyncElasticSearchHandler> logger, ElasticClientProvider elasticClientProvider)
        {
            _logger = logger;
            elasticClient = elasticClientProvider.Client;
        }

        public async Task<Nest.ISearchResponse<BackEnd.Data.DTO.PokemonDTO>> getSinglePokemonByIdAsync(int id)
        {
            _logger.LogInformation("[ {Time}  ] getSinglePokemonByIdAsync call to ElasticSearch DB invoked " +
                "through getPokemonAsync", DateTime.UtcNow);
            ISearchResponse<PokemonDTO> searchResponse = null;
            try
            {
                searchResponse = await elasticClient.SearchAsync<PokemonDTO>(s => s
                .Index("pokemon")
                .From(0)
                .Size(1)
                .Query(q => q
                 .Match(m => m
                .Field(f => f.id)
                .Query(id.ToString()))));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.ToString());
                throw (e);
            }

            return searchResponse;
        }

        public async Task<Nest.ISearchResponse<BackEnd.Data.DTO.PokemonDTO>> getPokemonAsync(string name)
        {
            _logger.LogInformation("[ {Time}  ] getPokemonAsync call to ElasticSearch DB invoked " +
                "through getPokemonAsync", DateTime.UtcNow);
            ISearchResponse<PokemonDTO> searchResponse = null;
            try
            {
                searchResponse = await elasticClient.SearchAsync<PokemonDTO>(s => s
                .Index("pokemon")
                .From(0)
                .Size(20)
                .Query(q => q
                 .Match(m => m
                .Field(f => f.name)
                .Query(name))));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.ToString());
                throw (e);
            }

            return searchResponse;
        }
    }
}