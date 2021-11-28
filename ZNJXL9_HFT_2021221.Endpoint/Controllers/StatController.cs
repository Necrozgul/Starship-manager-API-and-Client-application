using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZNJXL9_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStarshipLogic cl;

        public StatController(IStarshipLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public double AVGPrice()
        {
            return cl.AVGPrice();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return cl.AVGPriceByModels();
        }
    }
}
