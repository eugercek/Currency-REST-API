using System;
using System.Collections.Generic;
using API.Data.Contracts;
using API.Data.Models;
using API.Data.Repository;
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
        public ActionResult<IEnumerable<Currency>> Get()
        {
            if (_repo.IsTodayHasData())
            {
                return Ok(_repo.GetTodayCurrencies());
            }
            return NotFound("There is no currency data for today.");
        }

        [HttpGet]
        [Route("today/{name}")]
        public ActionResult<Currency> Get(string name)
        {
            if (_repo.IsTodayHasData())
            {
                var cur = _repo.GetTodayCurrencyByName(name);

                if (cur == null)
                {
                    return NotFound($"There is no currency names {name} for today.");
                }

                return cur;
            }
            return NotFound("There is no currency data for today.");
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
            if (_repo.IsDayHasData(relative))
            {
                return Ok(_repo.GetDayCurrencies(relative));
            }
            return NotFound("There is no currency data for today.");
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
    }
}
