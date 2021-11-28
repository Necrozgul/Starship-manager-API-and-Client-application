using System;
using System.Linq;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:51716");

            restService.Post<Brand>(new Brand()
            {
                Name = "Peugeot"
            }, "brands");

            var brands = restService.Get<Brand>("brands");
            var cars = restService.Get<Starship>("starships");
            var weapons = restService.Get<Weapon>("weapons");
            ; 
        }
        
    }
}
