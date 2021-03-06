using System.Collections.Generic;
using API.Data.Models;

namespace API.Data.Contracts
{
    public interface ICurrencyRepository : IRepository<Currency>
    {

        bool IsTodayHasData();
        bool IsDayHasData(int before);
        bool IsCurrencyCodeInData(string code);
        bool AreCurrencyCodesInData(params string[] code);

        IEnumerable<Currency> GetTodayCurrencies();
        IEnumerable<Currency> GetDayCurrencies(int relative);

        Currency GetTodayCurrencyByName(string name);
        Currency GetDayCurrencyByName(string name, int relative);

        decimal ConvertCurrencyToday(string from, string to);
        decimal ConvertCurrencyDay(string from, string to, int relative);

    }
}