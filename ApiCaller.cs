using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace II
{
    public class WebRequest
    {
        public static async Task GetPokemonDataAsync(int PokeId, Action<Dictionary<string,object>> Callback)
        {
            using (var Client =new HttpClient())
            {
                try
                {
                    Client.BaseAddress= new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response=await Client.GetAsync("");
                    Response.EnsureSuccessStatusCode();
                    string StringResponse=await Response.Content.ReadAsStringAsync();
                    Dictionary<string,object> JsonResponse=JsonConvert.DeserializeObject<Dictionary<string,object>>(StringResponse);
                    Callback(JsonResponse);
                }
                catch (HttpRequestException e)
                {
                    
                    System.Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}