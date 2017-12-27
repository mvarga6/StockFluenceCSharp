using System;
using System.Configuration;

namespace StockFluence.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get your api key for stockfluence from app settings
            string api_key = ConfigurationManager.AppSettings.Get("StockFluenceApiKey");
            Console.WriteLine($"Creating StockFluence client [ApiKey={api_key}]");

            // create a client
            var client = StockFluence.CreateClient(api_key);

            // test to run
            Methods.Test.GetFundTest        = true;
            Methods.Test.GetTopFundsTest    = true;
            Methods.Test.GetFundHistoryTest = true;

            // run the tests
            Methods.Test.RunTests(client);
        }
        
    }
}
