using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : Controller
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public OwnerController(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OwnerListDto>))]
    public async Task<IActionResult> GetOwners()
    {
        var owners = _ownerRepository.GetOwners();
        var dto = _mapper.Map<List<OwnerListDto>>(owners);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }
    
    [HttpGet("{ownerId}")]
    [ProducesResponseType(200, Type = typeof(OwnerListDto))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetOwner(int ownerId)
    {
        if (!await _ownerRepository.IsOwnerExists(ownerId))
        {
            NotFound();
        }

        var owner = await _ownerRepository.GetOwner(ownerId);
        var dto = _mapper.Map<OwnerListDto>(owner);
        if (!ModelState.IsValid)
            BadRequest(ModelState);
        return Ok(dto);
    }
}