using System.Collections.Generic;

namespace API.Data.Models
{

    // From: https://searchcode.com/codesearch/view/27836890/
    /// <summary>
    /// Enumeration of ISO 4217 currency codes, indexed with their respective ISO 4217 numeric currency codes. 
    /// Only codes support in .Net with RegionInfo objects are listed
    /// </summary>
    public static class CurrencyCodes
    {
        public static List<string> CurrencyCodeList = new List<string>{
            "ARS",
            "AUD",
            "AZN",
            "BAM",
            "BDT",
            "BGN",
            "BHD",
            "BND",
            "BOB",
            "BRL",
            "BYR",
            "BZD",
            "CAD",
            "CHF",
            "CLP",
            "CNY",
            "COP",
            "CRC",
            "CZK",
            "DKK",
            "DOP",
            "DZD",
            "EGP",
            "ETB",
            "EUR",
            "GBP",
            "GEL",
            "GTQ",
            "HKD",
            "HNL",
            "HRK",
            "HUF",
            "IDR",
            "ILS",
            "INR",
            "IQD",
            "IRR",
            "ISK",
            "JMD",
            "JOD",
            "JPY",
            "KES",
            "KGS",
            "KHR",
            "KRW",
            "KWD",
            "KZT",
            "LAK",
            "LBP",
            "LKR",
            "LTL",
            "LYD",
            "MAD",
            "MKD",
            "MNT",
            "MOP",
            "MVR",
            "MXN",
            "MYR",
            "NIO",
            "NOK",
            "NPR",
            "NZD",
            "OMR",
            "PAB",
            "PEN",
            "PHP",
            "PKR",
            "PLN",
            "PYG",
            "QAR",
            "RON",
            "RSD",
            "RUB",
            "RWF",
            "SAR",
            "SEK",
            "SGD",
            "SYP",
            "THB",
            "TJS",
            "TND",
            "TRY",
            "TTD",
            "TWD",
            "UAH",
            "USD",
            "UYU",
            "UZS",
            "VEF",
            "VND",
            "XOF",
            "YER",
            "ZAR"
            };

        public static bool IsCode(string code)
        {
            return CurrencyCodeList.Contains(code);
        }

        public static bool AreCodes(params string[] codes)
        {
            foreach (var code in codes)
            {
                if (!IsCode(code))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
