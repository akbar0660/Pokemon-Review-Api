using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly PokemonContext _context;

    public CategoryRepository(PokemonContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategory(int catId)
    {
        return await _context.Categories.FindAsync(catId);
    }

    public async Task<ICollection<Pokemon>> GetPokemonByCategory(int catId)
    {
        return await _context.PokemonCategories.Where(x => x.CategoryId == catId).Select(x => x.Pokemon).ToListAsync();
    }

    public async Task<bool> IsCategoryExists(int catId)
    {
        return await _context.Categories.AnyAsync(x => x.Id == catId);
    }
}