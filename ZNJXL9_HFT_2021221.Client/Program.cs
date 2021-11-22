using System;
using System.Linq;
using ZNJXL9_HFT_2021221.Client;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ProbaKiiratas:");
            XYZDbContext x = new XYZDbContext();



            var starshipData = from starship in x.Starships
                                            join brand in x.Brand
                                            on starship.BrandId equals brand.Id
                                            join weapon in x.Weapon
                                            on starship.WeaponId equals weapon.Id
                                            select new { Id = starship.Id , Model = starship.Model, Price = starship.BasePrice, Brand = brand.Name, BrandId=brand.Id, Weapon = weapon.Name, WeaponId = weapon.Id };


            var brandData = from brand in x.Brand select new { Id = brand.Id, Name = brand.Name };

            var weaponData = from weapon in x.Weapon select new { Id = weapon.Id, Name = weapon.Name };


            starshipData.ToConsole("starships");
            //brandData.ToConsole("brands");
            //weaponData.ToConsole("weapons");

            StarshipLogic s = new StarshipLogic(new StarshipRepository(x));
            BrandRepository b = new BrandRepository(x);
            WeaponRepository w = new WeaponRepository(x);

            s.Create(new Starship("Starshipcreatingwithnewmethod",2000,2,2));
            s.Update(new Starship(6,"StarshipcreatingwithnewmethodUpdated", 20000, 1, 1));
            s.GetBrandAverages().ToConsole("BrandAverage");
            
            //s.Delete(7);
            starshipData.ToConsole("starships");
        }
    }
}
