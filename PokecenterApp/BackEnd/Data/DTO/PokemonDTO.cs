/**
* Having a few issues with the serializer with strings, ints, etc that when I looked them up online I was recommended
* to make a DTO and convert.!-- So here is the Pokemon DTO.
*/ 

using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.DTO
{
    public class PokemonDTO
    {
        public string id { get; set; }
        public string attack { get; set; }
        public string base_total { get; set; }
        public string capture_rate { get; set; }
        public string defense { get; set; }
        public string experience_growth { get; set; }
        public string hp { get; set; }
        public string name { get; set; }
        public string percentage_male { get; set; }
        public string pokedex_number { get; set; }
        public string sp_attack { get; set; }
        public string sp_defense { get; set; }
        public string speed { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public string generation { get; set; }
        public string is_legendary { get; set; }
        public string trainer_id { get; set; }
    }
}