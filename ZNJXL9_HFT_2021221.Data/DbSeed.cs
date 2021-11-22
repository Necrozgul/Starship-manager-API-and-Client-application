using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Data
{
    public class DbSeed
    {
        public DbSeed()
        {
            adatok(starships, brands, weapons);
        }
        public static List<Brand> brands = new List<Brand>();
        public static List<Weapon> weapons = new List<Weapon>();
        public static List<Starship> starships = new List<Starship>();
        public static void adatok(List<Starship> starships, List<Brand> brands, List<Weapon> weapons)
        {
            
            Brand cec = new Brand() { Id = 1, Name = "CEC" };
            Brand cygnus = new Brand() { Id = 2, Name = "Cygnus" };
            Brand kuat = new Brand() { Id = 3, Name = "Kuat" };
            brands.Add(cec);
            brands.Add(cygnus);
            brands.Add(kuat);

            Weapon Turbolaser = new Weapon() { Id = 1, Name = "Turbo Laser" };
            Weapon Flacgun = new Weapon() { Id = 2, Name = "Flac Gun" };
            Weapon Protonbeambannon = new Weapon() { Id = 3, Name = "Proton Beam Cannon" };
            Weapon Orbitalautocannon = new Weapon() { Id = 4, Name = "Orbital Cannon" };
            weapons.Add(Turbolaser);
            weapons.Add(Flacgun);
            weapons.Add(Protonbeambannon);
            weapons.Add(Orbitalautocannon);


            Starship kuatEclipse = new Starship() { Id = 1, BrandId = kuat.Id, BasePrice = 200000, Model = "Eclipse", WeaponId = Orbitalautocannon.Id };
            Starship kuatExecutor = new Starship() { Id = 2, BrandId = kuat.Id, BasePrice = 30000, Model = "Executor", WeaponId = Orbitalautocannon.Id };
            Starship cecYV666 = new Starship() { Id = 3, BrandId = cec.Id, BasePrice = 10000, Model = "YV-666", WeaponId = Turbolaser.Id };
            Starship cecVCX100 = new Starship() { Id = 4, BrandId = cec.Id, BasePrice = 15000, Model = "VCX-150", WeaponId = Turbolaser.Id };
            Starship cygnusXwing = new Starship() { Id = 5, BrandId = cygnus.Id, BasePrice = 20000, Model = "XWing", WeaponId = Flacgun.Id };
            Starship cygnusT4a = new Starship() { Id = 6, BrandId = cygnus.Id, BasePrice = 25000, Model = "T-4A", WeaponId = Turbolaser.Id };
            starships.Add(kuatEclipse);
            starships.Add(kuatExecutor);
            starships.Add(cecYV666);
            starships.Add(cecVCX100);
            starships.Add(cygnusXwing);
            starships.Add(cygnusT4a);
        }
    }
}
