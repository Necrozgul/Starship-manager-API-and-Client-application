using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IEnumerable<Starship> GetAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Starship Get(int id)
        {
            return cl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Starship value)
        {
            cl.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Starship value)
        {
            cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}