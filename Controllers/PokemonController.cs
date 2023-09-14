using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Checkpoint.Data;
using CheckpointAPI.Data.DTOs;
using Checkpoint.Model;

namespace CheckpointAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
  private OracleDbContext _context;
  private IMapper _mapper;

  public PokemonController(OracleDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddPokemon([FromBody] CreatePokemonDto PokemonDto)
  {
    Pokemon pokemon = _mapper.Map<Pokemon>(PokemonDto);

    _context.Pokemons.Add(pokemon);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetPokemonById), new { id = pokemon.Id }, pokemon);
  }

  [HttpGet]
  public IEnumerable<ReadPokemonDto> GetAllUsers(
    [FromQuery] int skip = 0,
    [FromQuery] int take = 10,
    [FromQuery] string? nome = null
  )
  {
    if (nome != null)
    {
      return _mapper.Map<List<ReadPokemonDto>>(_context.Pokemons.Where((pokemon) => pokemon.Nome == nome));
    }

    return _mapper.Map<List<ReadPokemonDto>>(_context.Pokemons.Skip(skip).Take(take));
  }

  [HttpGet("{id}")]
  public IActionResult GetPokemonById(int id)
  {
    Pokemon? pokemon = _context.Pokemons.FirstOrDefault((pokemon) => pokemon.Id == id);

    if (pokemon == null)
    {
      return NotFound();
    }

    ReadPokemonDto pokeDto = _mapper.Map<ReadPokemonDto>(pokemon);

    return Ok(pokeDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdatePokemon(int id, [FromBody] UpdatePokemonDto pokeDto)
  {
    Pokemon? pokemon = _context.Pokemons.FirstOrDefault((user) => user.Id == id);

    if (pokemon == null)
    {
      return NotFound();
    }

    _mapper.Map(pokeDto, pokemon);
    _context.SaveChanges();

    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult PatchUser(int id, JsonPatchDocument<UpdatePokemonDto> patch)
  {
        Pokemon? user = _context.Pokemons.FirstOrDefault((user) => user.Id == id);

    if (user == null)
    {
      return NotFound();
    }

    UpdatePokemonDto userToUpdate = _mapper.Map<UpdatePokemonDto>(user);
    patch.ApplyTo(userToUpdate, ModelState);

    if (!TryValidateModel(userToUpdate))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(userToUpdate, user);
    _context.SaveChanges();

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteUser(int id)
  {
        Pokemon? pokemon = _context.Pokemons.FirstOrDefault((user) => user.Id == id);

    if (pokemon == null)
    {
      return NotFound();
    }

    _context.Remove(pokemon);
    _context.SaveChanges();

    return NoContent();
  }
}