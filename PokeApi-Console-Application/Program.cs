using PokeAPIConsumer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApi_Console_Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RequestPokemon();
        }

        public static async Task RequestPokemon()
        {
            Console.Write("Would you like to search a pokemon by ID or NAME? ");
            string type = Console.ReadLine().ToLower();
            if (type.Equals("id"))
            {
                await RequestPokemonById();
            }
            else if (type.Equals("name"))
            {
                RequestPokemonByName();
            }
            
        }

        public static async Task RequestPokemonById()
        {
            PokemonClient client = new PokemonClient();
            int id;
            Console.Write("What is the Pokedex Number of the pokemon you are attempting to search? ");
            string searchtype = Console.ReadLine();
            try
            {
                id = Convert.ToInt32(searchtype);
                PokemonResponse pr = await client.GetPokemon(id);
                Console.WriteLine($"{pr.name} | Pokedex No: {id}");
                Console.WriteLine($"{pr.name}'s Typing's");
                Console.WriteLine("=====================");
                foreach (var types in pr.types)
                {
                    Console.WriteLine(types.type.name);
                }
                Console.WriteLine();
                Console.WriteLine($"{pr.name}'s Abilites's");
                Console.WriteLine("=======================");
                foreach (var abilities in pr.abilities)
                {
                    if (!abilities.is_hidden)
                    {
                        Console.WriteLine("Normal Ability: " + abilities.ability.name);
                    }
                    else
                    {
                        Console.WriteLine("Hidden Ability: " + abilities.ability.name);
                    }
                }
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Sorry, but this is not a correct id or this pokemon does not exist.");
                Console.Write("Press Any Key To Exit....");
                Console.ReadKey();
            }
        }

        public static void RequestPokemonByName()
        {
            throw new NotImplementedException();
        }
    }
}
