﻿using System;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:51716");

            //restService.Post<Starship>(new Starship()
            //{
            //    Model = "UjApiModel",
            //    BasePrice = 154,
            //    BrandId = 1,
            //    WeaponId=1

            //}, "starship");

            var brands = restService.Get<Brand>("brand");
            var starships = restService.Get<Starship>("starship");
            var weapons = restService.Get<Weapon>("weapon");
            foreach (Starship item in starships)
            {
                Console.WriteLine(Environment.NewLine+item.ToString());
            }

        }
        
    }
}
