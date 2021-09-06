using System;
using System.Collections.Generic;
using System.Globalization;

namespace API.Extensions
{
    public static class Extension
    {
        [Obsolete("Couldn't finish")]
        public static List<string> GetAllISOCurrencySymbols(this CultureInfo cultureInfo)
        {
            var list = new List<string>();
            foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                try
                {
                    string x = new RegionInfo(c.LCID).ISOCurrencySymbol;
                    list.Add(x);
                }
                catch (System.Exception)
                {
                    continue;
                }
            }
            return list;
        }

    }
}
