using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // TODO LINQ
    [ApiController]
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
        public ActionResult<IEnumerable<Currency>> Get()
        {
            return _context.Currencies
                    .Where(c => c.Date == DateTime.Today)
                    .ToList();
        }

        [HttpGet]
        [Route("today/{name}")]
        public ActionResult<Currency> Get(string name)
        {
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                if (c.Name == name && c.Date == DateTime.Today)
                    return c;
            }
            return new Currency();
        }


        /*
            Gets relative time based on current day.
        */
        [HttpGet]
        [Route("{relative}/list")]
        public ActionResult<IEnumerable<Currency>> Get(int relative)
        {
            // TODO Should enhance API or strict API is better?
            // if (relative > 0)
            // {
            //     relative *= -1;
            // }

            return _context.Currencies
                    .Where(c => c.Date == DateTime.Today.AddDays(relative * -1))
                    .ToList();
        }

        [HttpGet]
        [Route("{relative}/{name}")]
        public ActionResult<Currency> Get(int relative, string name)
        {
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                if (c.Name == name && c.Date == DateTime.Today.AddDays(relative))
                    return c;
            }
            return new Currency();
        }
    }
}
