using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface ICategoryRepository
{
    Task<ICollection<Category>> GetCategories();
    Task<Category> GetCategory(int catId);
    Task<ICollection<Pokemon>> GetPokemonByCategory(int catId);
    Task<bool> IsCategoryExists(int catId);
}