using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Movie_Booking_API.Models;

namespace Movie_Booking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        /// <summary>
        /// Get the sgd number based on the label of currency and amount
        /// </summary>
        /// <remarks>
        [HttpGet("{amount}/{label}")]
        public async Task<IActionResult> Get(double amount, string label)
        {
            Currency currencyRes;
            double sgdAmount = 0;
            using(var httpClient = new HttpClient())
            {
                using(var resp = await httpClient.GetAsync(
                    "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/" + label + "/sgd.json"))
                {
                    string apiRes = await resp.Content.ReadAsStringAsync();
                    currencyRes = JsonConvert.DeserializeObject<Currency>(apiRes);
                    sgdAmount += (double)amount * currencyRes.sgd;
                }

            }
            return new JsonResult(sgdAmount);
        }
    }
}
