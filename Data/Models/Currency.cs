using System;

namespace API.Data.Models
{

    public class Currency
    {
        public int CurrencyID { get; set; }
        public string Name { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        // Very sad to see that C# Doesn't have static extension methods
        // https://github.com/dotnet/csharplang/discussions/2505
        // Waiting for the day!
        // public readonly static List<string> ISOCurrencySymbolList = (new CultureInfo("US")).GetAllISOCurrencySymbols();
    }
}
