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
    public class WeaponController : ControllerBase
    {
        IWeaponLogic logic;
        IHubContext<SignalRHub> hub;

        public WeaponController(IWeaponLogic brandLogic, IHubContext<SignalRHub> hub)
        {
            logic = brandLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Weapon> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Weapon Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Weapon value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("WeaponCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Weapon value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("WeaponUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("WeaponDeleted", logic.Read(id));
        }
    }
}
