using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Endpoint.Controllers
{
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        IWeaponLogic logic;

        public WeaponController(IWeaponLogic brandLogic)
        {
            logic = brandLogic;
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
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Weapon value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }


}
