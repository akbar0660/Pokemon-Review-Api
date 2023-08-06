using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IOwnerRepository
{
    Task<ICollection<Owner>> GetOwners();
    Task<Owner> GetOwner(int id);
    Task<ICollection<Owner>> GetOwnerOfAPokemon(int pokeId);
    Task<ICollection<Pokemon>> GetPokemonByOwnerId(int ownerId);
    Task<bool> IsOwnerExists(int ownerId);
}