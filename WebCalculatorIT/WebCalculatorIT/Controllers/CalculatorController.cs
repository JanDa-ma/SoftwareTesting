using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculatorIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        [HttpGet, Route(nameof(Sum))]
        public decimal Sum(decimal x, decimal y)
        {
            return new Calculator().Sum(x, y);
        }
    }
}