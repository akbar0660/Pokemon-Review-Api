using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface ICountryRepository
{
    Task<ICollection<Country>> GetCountries();
    Task<Country> GetCountry(int id);
    Task<Country> GetCountryByOwner(int ownerId);
    Task<ICollection<Owner>> GetOwnerByACountry(int countryId);
    Task<bool> IsCountryExist(int id);
}