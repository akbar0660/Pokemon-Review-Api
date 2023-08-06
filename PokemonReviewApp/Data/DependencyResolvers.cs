using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Data;

public static class DependencyResolvers
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PokemonContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}