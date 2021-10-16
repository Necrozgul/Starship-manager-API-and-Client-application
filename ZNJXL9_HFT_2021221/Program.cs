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



            var StarshipNameWithBrandName = from starship in x.Starships
                                            join brand in x.Brand
                                            on starship.BrandId equals brand.Id
                                            select new { Model = starship.Model, Brand = brand.Name };
            StarshipNameWithBrandName.ToConsole("starships");

            //x.StarshipNameChange(x, 1, "Probaname");
            //Működik
            StarshipRepository s = new StarshipRepository(x);
            //s.Delete(1);
            s.Create("Probaname", 20, 1,1);
            //s.Update("Probaupdated",);
            

            StarshipNameWithBrandName.ToConsole("starships");
        }
    }
}
