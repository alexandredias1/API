using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiConsoleApp
{
    class Program
    {
        // URL da API pública
        private static readonly string apiUrl = "https://catfact.ninja/fact";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Buscando um fato aleatório sobre gatos...");

            // Faz a chamada à API
            string catFact = await GetCatFact();

            // Exibe o fato
            Console.WriteLine("Fato sobre gatos: " + catFact);
        }

        static async Task<string> GetCatFact()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz a requisição GET para a API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lê o conteúdo da resposta como string
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                    else
                    {
                        return $"Erro na requisição. Código do status: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Erro ao chamar a API: {ex.Message}";
                }
            }
        }
    }
}
