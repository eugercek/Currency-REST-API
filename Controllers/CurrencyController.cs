using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("/")]
    public class CurrencyController : Controller
    {
        private readonly CurrencyContext _context;

        public CurrencyController(CurrencyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("today/list")]
        public List<Currency> Get()
        {
            var list = new List<Currency>();
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                list.Add(c);
            }
            return list;
        }

        [HttpGet]
        [Route("today/{name}")]
        public Currency Get(string name)
        {
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                if (c.Name == name)
                    return c;
            }
            return new Currency();
        }
    }
}
