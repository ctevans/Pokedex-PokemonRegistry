using BackEnd.Data.ElasticSearch;
using BackEnd.Data;
using BackEnd.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/**
* Provides access for the rest of the application to gain access to 
* pokemon specific functionality.
**/

namespace BackEnd.Services
{
    public class PokemonService
    {
        private DatabaseAccess databaseAccess;

        public PokemonService(DatabaseAccess databaseAccess)
        {
            this.databaseAccess = databaseAccess;
        }

        public async Task<List<Pokemon>> getPokemon(string name)
        {
            return await databaseAccess.getPokemon(name);
        }

        public async Task<Pokemon> getPokemonById(int id){
            return await databaseAccess.getPokemonById(id+1);
        }
    }
}