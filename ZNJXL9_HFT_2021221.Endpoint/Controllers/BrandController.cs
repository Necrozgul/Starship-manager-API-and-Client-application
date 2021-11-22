﻿
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
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic brandLogic)
        {
            logic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return logic.GetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            logic.Create(value);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Brand value)
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