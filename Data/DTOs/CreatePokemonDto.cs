using Checkpoint.Model;
using System.ComponentModel.DataAnnotations;

namespace CheckpointAPI.Data.DTOs;

public class CreatePokemonDto
{
  [Required(ErrorMessage = "Nome is required")]
  public string Nome { get; set; }

  [Required(ErrorMessage = "Nivel is required")]
  public int Nivel { get; set; }

  [Required(ErrorMessage = "Exp is required")]
  public float Exp { get; set; }

    [Required(ErrorMessage = "TipoPokemon is required")]
    public TipoPokemon Tipo { get; set; }


}