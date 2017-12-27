using System;
using System.Collections.Generic;
using System.Text;

namespace StockFluence.Models.Enums
{
    /// <summary>
    /// Enum for top fund types
    /// </summary>
    public enum TopFundType : byte
    {
        Losers = 0,
        Gainers = 1,
        Popular = 2
    }

    /// <summary>
    /// Simple extentions for enums
    /// </summary>
    //public static class EnumExtensions
    //{
    //    /// <summary>
    //    /// Extention that turns an enum into it's lower case name.
    //    /// Used for TopFunds API uri building.
    //    /// </summary>
    //    /// <param name="_this">TopFundType enum</param>
    //    /// <returns>It's name lowercased.</returns>
    //    public static string Name(this TopFundType _this)
    //    {
    //        return Enum.GetName(typeof(TopFundType), (byte)_this).ToLower();
    //    }
    //}
}
