using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZNJXL9_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStarshipLogic cl;
        IWeaponLogic wl;
        IBrandLogic bl;

        public StatController(IStarshipLogic cl, IBrandLogic bl, IWeaponLogic wl)
        {
            this.cl = cl;
            this.bl = bl;
            this.wl = wl;
        }

        [HttpGet]
        public double AVGPrice()
        {
            return cl.AVGPrice();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrand()
        {
            return cl.AVGPriceByBrand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByModel()
        {
            return cl.AVGPriceByModels();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByWeapon()
        {
            return cl.AVGPriceByWeapon();
        }
        [HttpGet]
        public Starship MostExpensiveStarship()
        {
            return cl.MostExpensiveStarship();
        }
        public Starship CheapestStarship()
        {
            return cl.CheapestStarship();
        }
    }
}
