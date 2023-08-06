using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IPokemonRepository
{
    Task<ICollection<Pokemon>> GetPokemons();
    Task<Pokemon> GetPokemon(int id);
    Task<Pokemon> GetPokemon(string name);
    Task<bool> IsPokemonExist(int pokeId);
}