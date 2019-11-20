using PokeAPIConsumer;
using System;

namespace PokeApi_Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestPokemon();
        }

        public static void RequestPokemon()
        {
            Console.Write("Would you like to search a pokemon by ID or NAME? ");
            string type = Console.ReadLine().ToLower();
            if (type.Equals("id"))
            {
                RequestPokemonById();
            }
            else if (type.Equals("name"))
            {
                RequestPokemonByName();
            }
            
        }

        public static async void RequestPokemonById()
        {
            PokemonClient client = new PokemonClient();
            int id;
            Console.Write("What is the Pokedex Number of the pokemon you are attempting to search? ");
            string searchtype = Console.ReadLine();
            try
            {
                id = Convert.ToInt32(searchtype);
                PokemonResponse pr = await client.GetPokemon(id);
                Console.Write($"{pr.name} | {pr.types} | {pr.abilities}");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Sorry, but this is not a correct id or this pokemon does not exist.");
                Console.Write("Press Any Key To Exit....");
                Console.ReadKey();
            }
        }

        public static async void RequestPokemonByName()
        {
            throw new NotImplementedException();
        }
    }
}
