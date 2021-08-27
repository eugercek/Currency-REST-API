using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        [HttpGet]
        public List<Currency> Get()
        {
            return Fake(3);
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