using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Models
{
    public class Pokemon
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int attack { get; set; }
        [Required]
        public int base_total { get; set; }
        [Required]
        public int capture_rate { get; set; }
        [Required]
        public int defense { get; set; }
        [Required]
        public int experience_growth { get; set; }
        [Required]
        public int hp { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double percentage_male { get; set; }
        [Required]
        public int pokedex_number { get; set; }
        [Required]
        public int sp_attack { get; set; }
        [Required]
        public int sp_defense { get; set; }
        [Required]
        public int speed { get; set; }
        [Required]
        public string type1 { get; set; }
        [Required]
        public string type2 { get; set; }
        [Required]
        public int generation { get; set; }
        [Required]
        public bool is_legendary { get; set; }
        [Required]
        public int trainer_id { get; set; }
    }
}