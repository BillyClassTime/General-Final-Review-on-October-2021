using System;
using Autorest.Sdk;
using System.Net.Http;
using Autorest.Sdk.Models;
using System.Collections.Generic;
using static System.Console;

namespace AutoRest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (
                sender, cert, chain, sslPolicyErrors) => {return true;};

            MyAPI client = new MyAPI(new Uri("http://localhost:5000"),clientHandler);
            IList<Destination> destinationList = client.ApiDestinationsGet();
            WriteLine("\nAll Destination");
            foreach (Destination destination in destinationList)
            {
                WriteLine($"{destination.CityName} - {destination.Airport}");
            }
            // ReadKey used that the console will not close when the code end to run.
            ReadKey();
        }
    }
}
