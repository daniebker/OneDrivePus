using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDrivePush.App
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadKey();
        }


        static async Task RunAsync()
        {
            var clientFactory = new ClientFactory();

            IClientApplication clientApplication = clientFactory.CreateClientApplication("bc74dbc7-d6e5-4e10-a2e1-30f3aeb11c0b");

            var tokenRetriever = new TokenRetriever(clientApplication);

            string token = await tokenRetriever.AquireTokenAsync();

            Console.WriteLine(token);
        }
    }
}
