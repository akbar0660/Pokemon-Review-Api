﻿namespace PokemonReviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
