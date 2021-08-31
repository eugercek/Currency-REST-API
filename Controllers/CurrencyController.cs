using System;
using System.Collections.Generic;
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
            var list = new List<Currency>();
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                if (c.Date == DateTime.Today)
                    list.Add(c);
            }
            return list;
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

            var list = new List<Currency>();
            foreach (var c in _context.Currencies.AsNoTracking())
            {
                if (c.Date == DateTime.Today.AddDays(relative * -1))
                    list.Add(c);
            }
            return list;
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
