using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Models;
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
            var list = _context.Currencies
                        .Where(c => c.Date == DateTime.Today)
                        .ToList();

            if (list.Any())
            {
                return list;
            }
            return NotFound("There is no currency data for today.");
        }

        [HttpGet]
        [Route("today/{name}")]
        public ActionResult<Currency> Get(string name)
        {
            var cur = _context.Currencies
                        .Where(c => c.Name == name && c.Date == DateTime.Today)
                        .FirstOrDefault();

            if (cur == null)
            {
                var list = _context.Currencies
                            .Where(c => c.Date == DateTime.Today)
                            .ToList();
                if (list.Any())
                {
                    return NotFound($"There is no {name} data.");
                }

                return NotFound("There is no currency data for today.");

            }

            return cur;
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


            var list = _context.Currencies
                        .Where(c => c.Date == DateTime.Today.AddDays(relative * -1))
                        .ToList();

            if (list.Any())
            {
                return list;
            }
            return NotFound($"There is no currency data for {relative} day(s) before.");
        }

        [HttpGet]
        [Route("{relative}/{name}")]
        public ActionResult<Currency> Get(int relative, string name)
        {
            var cur = _context.Currencies
                        .Where(c => c.Name == name && c.Date == DateTime.Today.AddDays(relative * -1))
                        .FirstOrDefault();

            if (cur == null)
            {
                var list = _context.Currencies
                            .Where(c => c.Date == DateTime.Today)
                            .ToList();
                if (list.Any())
                {
                    return NotFound($"There is no {name} data.");
                }

                return NotFound($"There is no currency data for {relative} day(s) before.");

            }

            return cur;
        }
    }
}
