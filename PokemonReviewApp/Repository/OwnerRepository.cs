using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly PokemonContext _context;

    public OwnerRepository(PokemonContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Owner>> GetOwners()
    {
        return await _context.Owners.ToListAsync();
    }

    public async Task<Owner> GetOwner(int id)
    {
        return await _context.Owners.FindAsync(id);
    }

    public async Task<ICollection<Owner>> GetOwnerOfAPokemon(int pokeId)
    {
        return await _context.PokemonOwners.Where(x => x.PokemonId == pokeId).Select(x => x.Owner).ToListAsync();
    }

    public async Task<ICollection<Pokemon>> GetPokemonByOwnerId(int ownerId)
    {
        return await _context.PokemonOwners.Where(x => x.OwnerId == ownerId).Select(x => x.Pokemon).ToListAsync();
    }

    public Task<bool> IsOwnerExists(int ownerId)
    {
        return _context.Owners.AnyAsync(x => x.Id == ownerId);
    }
}