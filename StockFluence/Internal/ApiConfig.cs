using System;
using System.Collections.Generic;
using System.Text;

namespace StockFluence.Internal
{
    /// <summary>
    /// Configuration of StockFluence's APIs
    /// </summary>
    internal class ApiConfig
    {
        /// <summary>
        /// The base api uri
        /// </summary>
        internal static Uri BaseApiUrl { get; private set; } = new Uri("http://api.stockfluence.com/");

        /// <summary>
        /// Uri to the fund operation, used for all calls so far.
        /// </summary>
        internal static Uri FundApiUrl { get; private set; } = new Uri(BaseApiUrl + "fund/");
    }
}
