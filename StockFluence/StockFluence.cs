using System;

namespace StockFluence
{
    /// <summary>
    /// Static wrapper class to creat a StockFluence ApiClient
    /// </summary>
    public static class StockFluence
    {
        /// <summary>
        /// Creates an Api client used to hit StockFluence's APIS
        /// </summary>
        /// <param name="apiKey">Your API key</param>
        /// <returns>Disposible ApiClient</returns>
        public static ApiClient CreateClient(string apiKey)
        {
            return new ApiClient(apiKey);
        }
    }
}
