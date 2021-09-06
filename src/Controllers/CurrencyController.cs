using System;
using System.Collections.Generic;
using API.Data.Contracts;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyRepository _repo;

        public CurrencyController(ICurrencyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("today/list")]
        public ActionResult<IEnumerable<Currency>> Get() => Get(0);

        [HttpGet]
        [Route("today/{name}")]
        public ActionResult<Currency> Get(string name) => Get(name, 0);

        [HttpGet]
        [Route("today/{from}/{to}")]
        public ActionResult<Currency> Get(string from, string to) => Get(from, to, 0);

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
            if (_repo.IsDayHasData(relative))
            {
                return Ok(_repo.GetDayCurrencies(relative));
            }
            return NotFound($"There is no currency data for {relative} day(s) before.");
        }

        [HttpGet]
        [Route("{relative}/{name}")]
        public ActionResult<Currency> Get(string name, int relative)
        {
            if (_repo.IsDayHasData(relative))
            {
                var cur = _repo.GetDayCurrencyByName(name, relative);

                if (cur == null)
                {
                    return NotFound($"There is no currency names {name} for {relative} day(s) before.");
                }
                return cur;
            }
            return NotFound($"There is no currency data for {relative} day(s) before.");
        }

        [HttpGet]
        [Route("{relative}/{from}/{to}")]
        public ActionResult<Currency> Get(string from, string to, int relative)
        {
            if (!CurrencyCodes.AreCodes(from, to))
            {
                string errorMessage = "";
                if (!CurrencyCodes.IsCode(from))
                {
                    errorMessage += $"from ({from}) is not valid ISO Currency Code\n";
                }
                if (!CurrencyCodes.IsCode(to))
                {
                    errorMessage += $"to ({to}) is not valid ISO Currency Code\n";
                }
                return BadRequest(errorMessage);
            }
            else if (!_repo.AreCurrencyCodesInData(from, to))
            {
                string errorMessage = "";
                if (!_repo.IsCurrencyCodeInData(from))
                {
                    errorMessage += $"from ({from}) is not in our database\n";
                }
                if (!CurrencyCodes.IsCode(to))
                {
                    errorMessage += $"to ({to}) is not in our database\n";
                }
                return BadRequest(errorMessage);
            }
            else if (_repo.IsDayHasData(relative))
            {
                var exchange = _repo.ConvertCurrencyDay(from, to, relative);
                return Ok(exchange);
            }

            return NotFound($"There is no currency data for {relative} day(s) before.");
        }
    }
}
