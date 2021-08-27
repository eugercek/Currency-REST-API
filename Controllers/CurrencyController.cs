using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "foo";
        }
    }
}