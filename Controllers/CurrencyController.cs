using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private readonly CurrencyContext _context;

        public CurrencyController(CurrencyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Currency> Get()
        {
            var list = new List<Currency>();
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                list.Add(c);
            }
            return list;
        }

        private List<Currency> Fake(int n)
        {
            var rand = new Random();
            var curs = new List<Currency>();

            for (int i = 0; i < n; i++)
            {
                curs.Add(new Currency
                {
                    Name = rand.NextDouble().ToString(),
                    BuyingPrice = ((decimal)rand.NextDouble()),
                    SellingPrice = ((decimal)rand.NextDouble()),
                });
            }

            return curs;

        }
    }
}
