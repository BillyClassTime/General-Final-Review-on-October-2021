using static System.Console;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace AutoRest.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
            (sender, ClientCertificateOption, ContextMarshalException, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                HttpResponseMessage message = await client.GetAsync("http://localhost:5000/api/destinations");
                WriteLine("Response data as string");
                string resultAsString = await message.Content.ReadAsStringAsync();
                WriteLine(resultAsString);

                List<Destination> destinationsResult = await message.Content.ReadAsAsync<List<Destination>>();

                WriteLine("All destination");
                foreach (Destination destination in destinationsResult)
                {
                    WriteLine($"{destination.CityName} - {destination.Airport}");
                }

            }
        }
    }
}
