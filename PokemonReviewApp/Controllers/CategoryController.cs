using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public async Task<IActionResult> GetCategories()
    {
        var categories =await _categoryRepository.GetCategories();
        var dto = _mapper.Map<List<CategoryListDto>>(categories);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }

    [HttpGet("{catId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCategory(int catId)
    {
        if (!await _categoryRepository.IsCategoryExists(catId))
        {
            NotFound();
        }

        var category = await _categoryRepository.GetCategory(catId);
        var dto = _mapper.Map<CategoryListDto>(category);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }

    [HttpGet("pokemon/{catId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByCategory(int catId)
    {
        var pokemons = _categoryRepository.GetPokemonByCategory(catId);
        var dto = _mapper.Map<List<PokemonListDto>>(pokemons);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }
}