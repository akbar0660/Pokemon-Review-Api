using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public async Task<IActionResult> GetAll()
    {
        var pokemons = await _pokemonRepository.GetPokemons();
        var dto = _mapper.Map<List<PokemonListDto>>(pokemons);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(dto);
    }

    [HttpGet("{pokeId}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetPokemon(int pokeId)
    {
        if (!await _pokemonRepository.IsPokemonExist(pokeId))
        {
            return NotFound();
        }

        var pokemon = await _pokemonRepository.GetPokemon(pokeId);
        var dto = _mapper.Map<PokemonListDto>(pokemon);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(dto);
    }

    // [HttpGet]
    // [ProducesResponseType(200, Type = typeof(decimal))]
    // [ProducesResponseType(400)]
}