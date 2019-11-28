using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Data.ElasticSearch;
using BackEnd.Data.Models;
using BackEnd.Data.DTO;
using System.Linq;

/**
* Maps the returned results from ElasticSearch into a List of Pokemon Models.
**/
namespace BackEnd.Data
{
    public class ElasticSearchToModelMapper
    {
        public ElasticSearchToModelMapper(AsyncElasticSearchHandler asyncElasticSearchHandler)
        {
            this.asyncElasticSearchHandler = asyncElasticSearchHandler;
        }

        AsyncElasticSearchHandler asyncElasticSearchHandler;

        /**
        * Executes the task to obtain the list of pokemon from ElasticSearch DB.
        **/
        public IReadOnlyCollection<BackEnd.Data.DTO.PokemonDTO> getListOfNestPokemonModelsFromElasticSearch(string name)
        {
            return asyncElasticSearchHandler.getPokemonAsync(name).Result.Documents;
        }

        /**
        * Executes the task to obtain a single pokemon by their unique ID from the ElasticSearchDB.
        **/ 
        public IReadOnlyCollection<BackEnd.Data.DTO.PokemonDTO> getSinglePokemonModelFromElasticSearchById(int id)
        {
            return asyncElasticSearchHandler.getSinglePokemonByIdAsync(id).Result.Documents;
        }

        public List<Pokemon> mapNESTPokemonToPokemonModels(IReadOnlyCollection<BackEnd.Data.DTO.PokemonDTO> pokemonDTOs)
        {
            List<Pokemon> mappedPokemonModels = new List<Pokemon>();

            foreach (PokemonDTO pokemonDTO in pokemonDTOs)
            {
                mappedPokemonModels.Add(mapSinglePokemonToModel(pokemonDTO));
            }

            return mappedPokemonModels;
        }

        /**
         * Performs the mapping onto the pokemon model objects.
         * Expensive with a lot of conversions, absolutely an area I'd want to optimize going forward.
         **/
        public Pokemon mapSinglePokemonToModel(BackEnd.Data.DTO.PokemonDTO pokemonDTO)
        {
            Pokemon pokemon = new Pokemon();

            pokemon.id = Convert.ToInt32(pokemonDTO.id) - 1;
            pokemon.attack = Convert.ToInt32(pokemonDTO.attack);
            pokemon.base_total = Convert.ToInt32(pokemonDTO.base_total);
            pokemon.capture_rate = Convert.ToInt32(pokemonDTO.capture_rate);
            pokemon.defense = Convert.ToInt32(pokemonDTO.defense);
            pokemon.experience_growth = Convert.ToInt32(pokemonDTO.experience_growth);
            pokemon.hp = Convert.ToInt32(pokemonDTO.hp);
            pokemon.name = pokemonDTO.name;
            pokemon.percentage_male = Convert.ToDouble(pokemonDTO.percentage_male);
            pokemon.pokedex_number = Convert.ToInt32(pokemonDTO.pokedex_number);
            pokemon.sp_attack = Convert.ToInt32(pokemonDTO.sp_attack);
            pokemon.sp_defense = Convert.ToInt32(pokemonDTO.sp_defense);
            pokemon.speed = Convert.ToInt32(pokemonDTO.speed);
            pokemon.type1 = pokemonDTO.type1;
            pokemon.type2 = pokemonDTO.type2;
            pokemon.generation = Convert.ToInt32(pokemonDTO.generation);
            pokemon.is_legendary = Convert.ToBoolean(Convert.ToInt32(pokemonDTO.is_legendary));
            pokemon.trainer_id = Convert.ToInt32(pokemonDTO.trainer_id);

            return pokemon;
        }

        /**
        * Returns the mapped list of pokemon retrieved from ElasticSearch DB.
        **/
        public List<Pokemon> getListOfPokemon(string name)
        {
            IReadOnlyCollection<BackEnd.Data.DTO.PokemonDTO> nestModels = getListOfNestPokemonModelsFromElasticSearch(name);
            return mapNESTPokemonToPokemonModels(nestModels);
        }

        public Pokemon getSinglePokemonById(int id)
        {
            BackEnd.Data.DTO.PokemonDTO pokemon = getSinglePokemonModelFromElasticSearchById(id).ElementAt(0);
            return mapSinglePokemonToModel(pokemon);
        }
    }
}