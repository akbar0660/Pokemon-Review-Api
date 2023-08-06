using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CountryListDto>))]
    public async Task<ActionResult> GetCountries()
    {
        var countries =await _countryRepository.GetCountries();
        var dto = _mapper.Map<List<CountryListDto>>(countries);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CountryListDto>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetCountry(int countryId)
    {
        var country = _countryRepository.GetCountry(countryId);
        var dto = _mapper.Map<CountryListDto>(country);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }

    [HttpGet("/owners/{ownerId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryOfAnOwner(int ownerId)
    {
        var country = _countryRepository.GetCountryByOwner(ownerId);
        var dto = _mapper.Map<CountryListDto>(country);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }
}