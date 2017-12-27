using StockFluence.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFluence.Internal
{
    /// <summary>
    /// Simple extentions for enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Extention that turns an enum into it's lower case name.
        /// Used for TopFunds API uri building.
        /// </summary>
        /// <param name="_this">TopFundType enum</param>
        /// <returns>It's name lowercased.</returns>
        internal static string Name(this TopFundType _this)
        {
            return Enum.GetName(typeof(TopFundType), (byte)_this).ToLower();
        }

        internal static string Name(this StockSymbol _this)
        {
            return Enum.GetName(typeof(StockSymbol), (int)_this).Replace('_', '.').ToLower();
        }
    }
}
