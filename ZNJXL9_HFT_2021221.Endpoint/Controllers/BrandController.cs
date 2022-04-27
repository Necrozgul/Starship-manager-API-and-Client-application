using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ZNJXL9_HFT_2021221.Endpoint.Services;
using System.Collections.Generic;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZNJXL9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic brandLogic, IHubContext<SignalRHub> hub)
        {
            logic = brandLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", id);
        }
    }
}
