using System;
using System.Collections.Generic;
using System.Text;

namespace StockFluence.Models
{
    /// <summary>
    /// Container for a history of FundData objects
    /// </summary>
    public class FundHistory : Dictionary<DateTime, FundData>{ }
}
