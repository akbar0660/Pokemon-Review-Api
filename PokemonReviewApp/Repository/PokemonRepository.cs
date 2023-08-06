using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonContext _context;

    public PokemonRepository(PokemonContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Pokemon>> GetPokemons()
    {
        var pokemons = await _context.Pokemons.OrderBy(x => x.Id).ToListAsync();
        return pokemons;
    }

    public async Task<Pokemon> GetPokemon(int id)
    {
        return await _context.Pokemons.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Pokemon> GetPokemon(string name)
    {
        return await _context.Pokemons.Where(x => x.Name == name).FirstOrDefaultAsync();
    }

    public async Task<bool> IsPokemonExist(int pokeId)
    {
        return await _context.Pokemons.AnyAsync(x => x.Id == pokeId);
    }
}