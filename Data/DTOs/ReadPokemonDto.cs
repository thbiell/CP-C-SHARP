using Checkpoint.Model;

namespace CheckpointAPI.Data.DTOs;

public class ReadPokemonDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
  public int Nivel { get; set; }
  public float Exp { get; set; }
  public TipoPokemon Tipo { get; set; }

}