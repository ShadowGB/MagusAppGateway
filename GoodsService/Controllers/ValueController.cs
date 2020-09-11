using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1 from Good Api", "value2 from Good Api" };
        }
    }
}