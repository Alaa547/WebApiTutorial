using WebApiTutorial.Models;

namespace WebApiTutorial.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(String name);
        decimal GetPokemonRating(int pokeid);
        bool PokemonExists(int pokeId);


    }
}
