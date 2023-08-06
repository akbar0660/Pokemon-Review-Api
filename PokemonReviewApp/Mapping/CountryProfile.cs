using AutoMapper;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mapping;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryListDto>().ReverseMap();
    }
}