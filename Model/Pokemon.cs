using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint.Model
{
    [Table("Pokemons")]
    public class Pokemon
    {
        [Key]
	    [Required]
        public int Id { get; set; }

	    [Required(ErrorMessage = "Nome is required")]
        public string Nome { get; set; }
	    [Required(ErrorMessage = "Nivel is required")]
        public int Nivel { get; set; }

        [Required(ErrorMessage = "Exp is required")]
        public float Exp { get; set; }
        [Required(ErrorMessage = "TipoPokemon is required")]
         public TipoPokemon Tipo { get; set; }
        public Pokemon()
        {

        }
        public Pokemon(int id, String nome, int nivel, float exp, TipoPokemon tipo)
        {
            Id = id;
            Nome = nome;
            Nivel = nivel;
            Exp = exp;
            Tipo = tipo;
        }
    }
    public enum TipoPokemon
    {
        Agua,
        Fogo,
        Planta,
        Eletrico,
        Fantasma,
        Lendario
    }
}
   

