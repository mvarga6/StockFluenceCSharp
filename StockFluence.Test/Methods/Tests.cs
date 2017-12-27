using StockFluence.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFluence.Test.Methods
{
    public static class Test
    {
        public static bool GetTopFundsTest { get; set; } = false;
        public static bool GetFundTest { get; set; } = false;
        public static bool GetFundHistoryTest { get; set; } = true;

        public static void RunTests(ApiClient client)
        {
            GetTopFunds(client);
            GetFund(client);
            GetFundHistory(client);

            Console.WriteLine("Press any key to end ...");
            Console.ReadKey();
        }

        public static void GetFundHistory(ApiClient client)
        {
            if (GetFundHistoryTest)
            {
                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetFundHistory\t");
                try
                {
                    var getFundHistoryResult = client.GetFundHistory(StockSymbol.AAPL, new DateTime(2017, 1, 1), new DateTime(2017, 3, 1));

                    if (getFundHistoryResult.Any())
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                }

                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetFundHistoryAsync\t");
                try
                {
                    var getFundHistoryResult = client.GetFundHistoryAsync(StockSymbol.ADS_DE, new DateTime(2017, 1, 1), new DateTime(2017, 3, 1)).GetAwaiter().GetResult();

                    if (getFundHistoryResult.Any())
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                }
            }
        }

        public static void GetTopFunds(ApiClient client)
        {
            if (GetTopFundsTest)
            {
                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetTopFunds\t");
                try
                {
                    var getTopFundsResult = client.GetTopFunds(Models.Enums.TopFundType.Losers);

                    if (getTopFundsResult.Any())
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                }

                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetTopFundsAsync\t");
                try
                {
                    var getTopFundsAsyncResult = client.GetTopFundsAsync(Models.Enums.TopFundType.Popular).GetAwaiter().GetResult();

                    if (getTopFundsAsyncResult.Any())
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                } 
            }
        }

        public static void GetFund(ApiClient client)
        {
            if (GetFundTest)
            {
                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetFund\t");
                try
                {
                    var getFundResult = client.GetFund("AAPL");

                    if (getFundResult != null)
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                }


                Console.WriteLine();
                Console.Write("[ TEST ] METHOD: GetFund\t");
                try
                {
                    var getFundAsyncResult = client.GetFundAsync(StockSymbol.BBED_AS).GetAwaiter().GetResult();

                    if (getFundAsyncResult != null)
                    {
                        Console.Write("Result: Success");
                    }
                    else
                    {
                        Console.Write("Result: Empty");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Result: Exception");
                    throw;
                } 
            }
        }
    }
}
