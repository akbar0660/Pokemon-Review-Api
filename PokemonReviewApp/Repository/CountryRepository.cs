using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly PokemonContext _context;
    private readonly IMapper _mapper;

    public CountryRepository(PokemonContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ICollection<Country>> GetCountries()
    {
        return await _context.Countries.ToListAsync();
    }

    public async Task<Country> GetCountry(int id)
    {
        return await _context.Countries.FindAsync(id);
    }

    public async Task<Country> GetCountryByOwner(int ownerId)
    {
        return await _context.Owners.Where(x => x.Id == ownerId).Select(x => x.Country).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Owner>> GetOwnerByACountry(int countryId)
    {
        return await _context.Owners.Where(x => x.Country.Id == countryId).ToListAsync();
    }

    public async Task<bool> IsCountryExist(int id)
    {
        return await _context.Countries.AnyAsync(x=>x.Id==id);
    }
}