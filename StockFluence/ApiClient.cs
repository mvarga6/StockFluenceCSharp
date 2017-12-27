using StockFluence.Internal;
using StockFluence.Models;
using StockFluence.Models.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockFluence
{
    public class ApiClient : IDisposable
    {
        /// <summary>
        /// The key used for api authentication
        /// </summary>
        private readonly string api_key;

        /// <summary>
        /// Used to make http requests
        /// </summary>
        private HttpClient client = new HttpClient()
        {
            BaseAddress = Internal.ApiConfig.FundApiUrl,
            Timeout = TimeSpan.FromSeconds(30)
        };

        /// <summary>
        /// Internally protected constructor.  User should use StockFluence
        /// factory method to create ApiClient
        /// </summary>
        /// <param name="apiKey"></param>
        internal ApiClient(string apiKey)
        {
            api_key = apiKey;
        }

        /// <summary>
        /// Asyncronously get top [gainers/losers/popular] symbols.
        /// </summary>
        /// <param name="type">The type of top symbols you want</param>
        /// <returns>Task to a list of FundData objects</returns>
        public async Task<IEnumerable<FundData>> GetTopFundsAsync(TopFundType type)
        {
            try
            {
                var response = await client.GetAsync($"type/{type.Name()}?apikey={api_key}");
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsAsync<List<FundData>>();
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get top [gainers/losers/popular] symbols.
        /// </summary>
        /// <param name="type">The type of top symbols you want</param>
        /// <returns>List of FundData objects</returns>
        public IEnumerable<FundData> GetTopFunds(TopFundType type)
        {
            try
            {
                var response = client.GetAsync($"type/{type.Name()}?apikey={api_key}").GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<List<FundData>>().GetAwaiter().GetResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Asyncronously get the most recent data for a stock symbol
        /// </summary>
        /// <param name="symbol">The stock symbol we want data for</param>
        /// <returns>FundData object for this symbol</returns>
        public async Task<FundData> GetFundAsync(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol", "GetFundAsync requires a non-null symbol");
            }

            try
            {
                var response = await client.GetAsync($"{symbol.ToUpper()}?apikey={api_key}");
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsAsync<FundData>();
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FundData> GetFundAsync(StockSymbol symbol)
        {
            return await GetFundAsync(symbol.Name());
        }

        /// <summary>
        /// Get the most recent data for a stock symbol
        /// </summary>
        /// <param name="symbol">The stock symbol we want data for</param>
        /// <returns>FundData object for this symbol</returns>
        public FundData GetFund(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol", "GetFund requires a non-null symbol");
            }

            try
            {
                var response = client.GetAsync($"{symbol.ToUpper()}?apikey={api_key}").GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<FundData>().GetAwaiter().GetResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FundData GetFund(StockSymbol symbol)
        {
            return GetFund(symbol.Name());
        }

        /// <summary>
        /// Asyncronously get historical FundData for a symbol in a given time period
        /// </summary>
        /// <param name="symbol">Symbol we want data for</param>
        /// <param name="startDate">Start of history</param>
        /// <param name="endDate">End of history</param>
        /// <returns>FundHistory (DateTime/FundDate Dictionary)</returns>
        public async Task<FundHistory> GetFundHistoryAsync(string symbol, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol", "GetFundHistoryAsync requires a non-null symbol");
            }
            
            try
            {
                string start = startDate.ToString("yyyy-MM-dd");
                string end = endDate.ToString("yyyy-MM-dd");
                var response = await client.GetAsync($"{symbol.ToUpper()}/history/{start}/{end}?apikey={api_key}");
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsAsync<FundHistory>();
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FundHistory> GetFundHistoryAsync(StockSymbol symbol, DateTime startDate, DateTime endDate)
        {
            return await GetFundHistoryAsync(symbol.Name(), startDate, endDate);
        }
        
        /// <summary>
        /// Get historical FundData for a symbol in a given time period
        /// </summary>
        /// <param name="symbol">Symbol we want data for</param>
        /// <param name="startDate">Start of history</param>
        /// <param name="endDate">End of history</param>
        /// <returns>FundHistory (DateTime/FundDate Dictionary)</returns>
        public FundHistory GetFundHistory(string symbol, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol", "GetFundHistory requires a non-null symbol");
            }

            try
            {
                string start = startDate.ToString("yyyy-MM-dd");
                string end = endDate.ToString("yyyy-MM-dd");
                var response = client.GetAsync($"{symbol.ToUpper()}/history/{start}/{end}?apikey={api_key}").GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<FundHistory>().GetAwaiter().GetResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FundHistory GetFundHistory(StockSymbol symbol, DateTime startDate, DateTime endDate)
        {
            return GetFundHistory(symbol.Name(), startDate, endDate);
        }

        /// <summary>
        /// Dispose internal HttpClient
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
