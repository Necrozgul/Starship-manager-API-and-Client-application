using System;
using System.Linq;
using ZNJXL9_HFT_2021221.Client;
using ZNJXL9_HFT_2021221.Data;
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
                                            select new { Model = starship.Model, Id = starship.Id , Brand = brand.Name, Weapon = weapon.Name };


            var brandData = from brand in x.Brand select new { Id = brand.Id, Name = brand.Name };

            var weaponData = from weapon in x.Weapon select new { Id = weapon.Id, Name = weapon.Name };


            starshipData.ToConsole("starships");

            //x.StarshipNameChange(x, 1, "Probaname");
            //Működik
            StarshipRepository s = new StarshipRepository(x);
            BrandRepository b = new BrandRepository(x);
            WeaponRepository w = new WeaponRepository(x);
        }
    }
}
