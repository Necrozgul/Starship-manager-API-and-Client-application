using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using ZNJXL9_HFT_2021221.Endpoint.Services;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        IStarshipLogic logic;
        IHubContext<SignalRHub> hub;

        public StarshipController(IStarshipLogic cl, IHubContext<SignalRHub> hub)
        {
            this.logic = cl;
            this.hub = hub;
        }
        // GET: /car
        [HttpGet]
        public IEnumerable<Starship> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Starship Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Starship value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("StarshipCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Starship value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("StarshipUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("StarshipDeleted", logic.Read(id));
        }
    }
}