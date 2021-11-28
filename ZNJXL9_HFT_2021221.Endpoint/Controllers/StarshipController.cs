using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        IStarshipLogic cl;

        public StarshipController(IStarshipLogic cl)
        {
            this.cl = cl;
        }

        // GET: /car
        [HttpGet]
        public IEnumerable<Starship> Get()
        {
            return cl.ReadAll();
        }

        // GET /car/5
        [HttpGet("{id}")]
        public Starship Get(int id)
        {
            return cl.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Starship value)
        {
            cl.Create(value);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] Starship value)
        {
            cl.Update(value);
        }

        // DELETE car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
