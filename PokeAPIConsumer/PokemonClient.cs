using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeAPIConsumer
{
    public class PokemonClient
    {
        private static readonly HttpClient Client;

        static PokemonClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }
        /// <summary>
        /// Returns a single pokemon data using Id.
        /// </summary>
        /// <param name="id">The Id of the pokemon</param>
        public async Task<PokemonResponse> GetPokemon(int id)
        {
            HttpResponseMessage resp =
                await Client.GetAsync($"pokemon/{id}");
            if (resp.IsSuccessStatusCode)
            {
                string data = await resp.Content.ReadAsStringAsync();
                PokemonResponse pr = JsonConvert.DeserializeObject<PokemonResponse>(data);

                return pr;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a single pokemon data using name.
        /// </summary>
        /// <param name="name">The name of the pokemon</param>
        public async Task<PokemonResponse> GetPokemon(string name)
        {
            HttpResponseMessage resp =
                    await Client.GetAsync($"{name}");
            if (resp.IsSuccessStatusCode)
            {
                string data = await resp.Content.ReadAsStringAsync();
                PokemonResponse pr = JsonConvert.DeserializeObject<PokemonResponse>(data);

                return pr;
            }
            else
            {
                return null;
            }
        }
    }
}
