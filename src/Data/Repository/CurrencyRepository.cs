using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Contracts;
using API.Data.Models;
using API.Extensions;

namespace API.Data.Repository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private new CurrencyContext _context;

        public CurrencyRepository(CurrencyContext context) : base(context)
        {
            _context = context;
        }

        private bool isDayHasData(int relative) => _context.Currencies.Any(c => c.Date == DateTime.Today.AddDays(relative * -1));

        private Currency getCurrecyByName(string name, int relative) =>
            _context.Currencies
            .Where(c => c.Name == name && c.Date == DateTime.Today.AddDays(relative * -1))
            .FirstOrDefault();

        private IEnumerable<Currency> getCurrencies(int relative) =>
            _context.Currencies
            .Where(c => c.Date == DateTime.Today.AddDays(relative * -1))
            .ToList();

        private Currency getCurrencyByISOCode(string code, int relative) =>
            _context.Currencies
            .Where(c => c.Code == code && c.Date == DateTime.Today.AddDays(relative * -1))
            .FirstOrDefault();


        public bool IsTodayHasData() => isDayHasData(0);
        public bool IsDayHasData(int before) => isDayHasData(before);

        public IEnumerable<Currency> GetTodayCurrencies() => getCurrencies(0);
        public IEnumerable<Currency> GetDayCurrencies(int relative) => getCurrencies(relative);

        public Currency GetTodayCurrencyByName(string name) => getCurrecyByName(name, 0);
        public Currency GetDayCurrencyByName(string name, int relative) => getCurrecyByName(name, relative);

        public decimal ConvertCurrencyToday(string from, string to)
        {
            return getCurrencyByISOCode(from, 0).BuyingPrice / getCurrencyByISOCode(to, 0).BuyingPrice;
        }

        public decimal ConvertCurrencyDay(string from, string to, int relative)
        {
            return getCurrencyByISOCode(from, relative).BuyingPrice / getCurrencyByISOCode(to, relative).BuyingPrice;
        }

        public bool IsCurrencyCodeInData(string code) =>
            _context.Currencies
            .Select(c => c.Code)
            .ToList()
            .Contains(code);

        public bool AreCurrencyCodesInData(params string[] code) =>
            _context.Currencies
            .Select(c => c.Code)
            .ToList()
            .ContainsForAll(code);
    }
}