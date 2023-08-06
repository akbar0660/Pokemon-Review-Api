using AutoMapper;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mapping;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        CreateMap<Pokemon, PokemonListDto>().ReverseMap();
    }
}