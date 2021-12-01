using System;
using System.Collections.Generic;
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

            var brands = restService.Get<Brand>("brand");
            var starships = restService.Get<Starship>("starship");
            var weapons = restService.Get<Weapon>("weapon");
            #region Probastarships
            //restService.Post<Starship>(new Starship()
            //{
            //    Model = "Model7",
            //    WeaponId = 1,
            //    BrandId = 1,
            //    BasePrice = 15,

            //}, "starship");
            //restService.Put<Starship>(new Starship()
            //{
            //    Id = 7,
            //    Model = "editedmodel",
            //    WeaponId = 1,
            //    BrandId= 1,
            //    BasePrice = 15,

            //},"starship");
            #endregion
            MenuShow();
            ConsoleMenu(restService);
            
        }
        static void ConsoleMenu(RestService restService)
        {
            Console.WriteLine("Type a command to do something:");
            ConsoleKeyInfo chinput;
            do
            {
                chinput = Console.ReadKey();
                string info = "";
                switch (chinput.Key)
                {
                    case ConsoleKey.D1:
                        MenuInsertItem(restService);
                        info = "Inserting was Succesfull";
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.D2:
                        MenuModifyItem(restService);
                        //Console.WriteLine("Under Construction");
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.D3:
                        MenuRemoveItem(restService);
                        info = "Deleting was Succesfull";
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.D4:
                        ListItems(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.A:
                        MenuAVGPrice(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.Z:
                        MenuMostExpensiveStarship(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.E:
                        MenuCheapestStarship(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.B:
                        MenuAveragePriceByBrand(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.M:
                        MenuAveragePriceByModel(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.W:
                        MenuAveragePriceByWeapon(restService);
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        MenuShow();
                        break;
                    default:
                        Console.WriteLine(info);
                        break;
                    
                }
                Console.WriteLine("Type a new command to do something:");
                Console.WriteLine();
            } while (chinput.Key != ConsoleKey.X);
        }
        static void MenuShow()
        {
            Console.WriteLine("################  Menu  ################");
            Console.WriteLine("Press the buttons on your keyboard: ");
            Console.WriteLine("[1] Adding item");
            Console.WriteLine("[2] Modify item");
            Console.WriteLine("[3] Remove item");
            Console.WriteLine("[4] List of the specific items");
            Console.WriteLine("[A] Average Starship Price");
            Console.WriteLine("[Z] Most Expensive Starship");
            Console.WriteLine("[E] Cheapest starship");
            Console.WriteLine("[B] AVG Price - Brand");
            Console.WriteLine("[M] AVG Price - Model");
            Console.WriteLine("[W] AVG Price - Weapon");
            Console.WriteLine("[B] AveragePriceByBrand");
            Console.WriteLine("[c] Clear the Console");
            Console.WriteLine("[x] stop the program");
            Console.WriteLine("#########################################");
        }
        static void MenuInsertItem(RestService restService)
        {
            try
            {
                Console.WriteLine("\nGive the name of the table: (starship,brand,weapon)");
                string tabblename = Console.ReadLine();
                if (tabblename == "starship")
                {
                    Console.WriteLine("Starship name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Weapon id: ");
                    int weaponid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Brand id: ");
                    int brandid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Price: ");
                    int price = int.Parse(Console.ReadLine());
                    restService.Post(new Starship() { Model = name, BrandId = brandid, WeaponId = weaponid, BasePrice = price }, tabblename);
                }
                else if (tabblename == "brand")
                {
                    Console.WriteLine("Brand Name: ");
                    string name = Console.ReadLine();
                    restService.Post(new Brand() { Name = name }, tabblename);
                }
                else if (tabblename == "brand")
                {
                    Console.WriteLine("Weapon Name: ");
                    string name = Console.ReadLine();
                    restService.Post(new Weapon() { Name = name }, tabblename);
                }
                else
                {
                    throw new ArgumentException("There is no table with that name");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MenuModifyItem(RestService restService)
        {
            try
            {
                Console.WriteLine("\nGive the name of the table: (starship,brand,weapon)");
                string tabblename = Console.ReadLine();
                if (tabblename == "starship")
                {
                    Console.WriteLine("[Editing]\nType id here:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Starship name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Weapon id: ");
                    int weaponid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Brand id: ");
                    int brandid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Price: ");
                    int price = int.Parse(Console.ReadLine());
                    restService.Put(new Starship() { Id = id, Model = name, BrandId = brandid, WeaponId = weaponid, BasePrice = price }, tabblename);
                    Console.WriteLine("Editing was succesfull!");
                }
                else if (tabblename == "brand")
                {
                    Console.WriteLine("[Editing]\nType id here:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Brand Name: ");
                    string name = Console.ReadLine();
                    restService.Put(new Brand() { Id = id, Name = name }, tabblename);
                    Console.WriteLine("Editing was succesfull!");
                }
                else if (tabblename == "weapon")
                {
                    Console.WriteLine("[Editing]\nType id here:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Weapon Name: ");
                    string name = Console.ReadLine();
                    restService.Put(new Weapon() { Id = id, Name = name }, tabblename);
                    Console.WriteLine("Editing was succesfull!");
                }
                else
                {
                    throw new ArgumentException("There is no table with that name");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Az adott elem módosítása sikertelen!\n"+ex.Message);
            }
        }
        static void MenuRemoveItem(RestService restService)
        {
            try
            {
                Console.WriteLine("\nGive the name of the table: (starship,brand,weapon)");
                string tabblename = Console.ReadLine();
                Console.WriteLine("\nType the id of the item you want to remove");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, tabblename);
                Console.WriteLine("Removing was succesfull!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("[Error]"+ex.Message);
            }
            
        }
        static void ListItems(RestService restService) 
        {
            try
            {
                Console.WriteLine("\nGive the name of the table you want to list: (starship,brand,weapon)");
                string tabblename = Console.ReadLine();
                string data_ = "";
                if (tabblename == "starship")
                {
                    var datas = restService.Get<Starship>("starship");
                    foreach (Starship data in datas)
                    {
                        data_ += $"\n{data.ToString()}";
                    }
                }
                if (tabblename == "brand")
                {
                    var datab = restService.Get<Brand>("brand");
                    foreach (Brand data in datab)
                    {
                        data_ += $"\n{data.ToString()}";
                    }
                }
                if (tabblename == "weapon")
                {
                    var dataw = restService.Get<Weapon>("weapon");
                    foreach (Weapon data in dataw)
                    {
                        data_ += $"\n{data.ToString()}";
                    }
                }
                Console.WriteLine(data_);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Listing Failed] "+ex.Message);
            }
        }
        static void MenuAveragePriceByBrand(RestService restService) 
        {
            try
            {
                Console.WriteLine("\nAVG Price by Brand:");
                var x =
                    restService.Get<KeyValuePair<string, double>>("stat/avgpricebybrand");
                string text = "";
                foreach (var item in x)
                {
                    text += ($"\n[{item.Key}] Price: {item.Value}");
                }
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[Error] {ex.Message}");
            }
        }
        static void MenuAveragePriceByModel(RestService restService)
        {
            try
            {
                Console.WriteLine("\nAVG Price by Model:");
                var x =
                    restService.Get<KeyValuePair<string, double>>("stat/avgpricebymodel");
                string text = "";
                foreach (var item in x)
                {
                    text += ($"\n[{item.Key}] Price: {item.Value}");
                }
                Console.WriteLine(text);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"[Error] {ex.Message}");
            }
        }
        static void MenuAveragePriceByWeapon(RestService restService)
        {
            
            try
            {
                Console.WriteLine("\nAVG Price by Weapon:");
                var x =
                    restService.Get<KeyValuePair<string, double>>("stat/avgpricebyweapon");
                string text = "";
                foreach (var item in x)
                {
                    text += ($"\n[{item.Key}] Price: {item.Value}");
                }
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"[Error] {ex.Message}");
            }
        }
        static void MenuMostExpensiveStarship(RestService restService)
        {
            try
            {
                Starship x = restService.GetSingle<Starship>("stat/mostexpensivestarship");
                Console.WriteLine("\nThe most expensive starship:");
                Console.WriteLine(x);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error] "+ex.Message);
            }         
        }
        static void MenuCheapestStarship(RestService restService)
        {
            try
            {
                Starship x = restService.GetSingle<Starship>("stat/cheapeststarship");
                Console.WriteLine("\nthe Ceapest Starship:");
                Console.WriteLine(x);
            }
            catch (Exception ex)
            {

                Console.WriteLine("[Error] "+ex.Message);
            }
            
        }
        static void MenuAVGPrice(RestService restService)
        {
            try
            {
                var x = restService.GetSingle<double>("stat/avgprice");
                Console.WriteLine("Average price of the starships:");
                Console.WriteLine(x);
            }
            catch (Exception ex)
            {

                Console.WriteLine("[Error] "+ex.Message);
            }
            
        }
    }
}
