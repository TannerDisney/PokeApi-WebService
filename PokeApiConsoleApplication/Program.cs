using System;
using PokeAPIConsumer;
using PokeApiNet.Models;

namespace PokeApiConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CallPokemon();
        }

        public static async void CallPokemon()
        {
            Console.Write("What pokemon would you like to search?(Make sure to use numbers): ");
            int line = Convert.ToInt32(Console.ReadLine());
            Pokemon pokemon = await PokemonClient.GetPokemonByName(line);
            Console.WriteLine(pokemon.Name);
            Console.ReadKey();
        }
    }
}
