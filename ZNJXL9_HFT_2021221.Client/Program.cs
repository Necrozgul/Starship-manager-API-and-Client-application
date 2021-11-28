using System;
using System.Threading;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:51716");
            Thread.Sleep(8000);

            restService.Post(
                new Starship()
                {
                    Model = "ManualModelAdd",
                    WeaponId =  1,
                    BrandId = 1,
                    BasePrice =  15
                    
                },"starship");
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
