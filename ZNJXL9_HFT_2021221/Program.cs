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
            Console.WriteLine(x.Starships.Count());
            //x.Starships.Select(x=>x.Model).ToConsole("starships");



            var StarshipFullData = from starship in x.Starships
                                            join brand in x.Brand
                                            on starship.BrandId equals brand.Id
                                            join weapon in x.Weapon
                                            on starship.WeaponId equals weapon.Id
                                            select new { Model = starship.Model, Id = starship.Id , Brand = brand.Name, Weapon = weapon.Name };
            StarshipFullData.ToConsole("starships");

            //x.StarshipNameChange(x, 1, "Probaname");
            //Működik
            StarshipRepository s = new StarshipRepository(x);
            //s.Delete(1);
            s.Create("Probaname", 20, 1,1);//7id
            StarshipFullData.ToConsole("starships");
            s.Update(7,"Proba", 20, 2, 2);

            StarshipFullData.ToConsole("starships");
        }
    }
}
