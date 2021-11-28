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
            Thread.Sleep(3000);

            var brands = restService.Get<Brand>("brand");
            var starships = restService.Get<Starship>("starship");
            var weapons = restService.Get<Weapon>("weapon");
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
                        //MenuModifyItem(restService);
                        Console.WriteLine("Under Construction");
                        //Console.WriteLine(info);
                        break;
                    case ConsoleKey.D3:
                        MenuRemoveItem(restService);
                        info = "Deleting was Succesfull";
                        Console.WriteLine(info);
                        break;
                    case ConsoleKey.D4:
                        info = ListItems(restService);
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
            Console.WriteLine("[1] Adding item.");
            Console.WriteLine("[2] Modify item.");
            Console.WriteLine("[3] Remove item.");
            Console.WriteLine("[4] List of the specific items");
            Console.WriteLine("[c] Clear the Console");
            Console.WriteLine("[x] stop the program");
            Console.WriteLine("#########################################");
        }
        static void MenuInsertItem(RestService restService)
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
                restService.Post(new Starship() { Model=name, BrandId = brandid, WeaponId = weaponid, BasePrice = price}, tabblename);
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
        static void MenuModifyItem(RestService restService)
        {
            //Console.WriteLine("\nGive the name of the table: (starship,brand,weapon)");
            //string tabblename = Console.ReadLine();
            //if (tabblename == "starship")
            //{
            //    Console.WriteLine("[Editing]\nType id here:");
            //    int id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Starship name: ");
            //    string name = Console.ReadLine();
            //    Console.WriteLine("Weapon id: ");
            //    int weaponid = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Brand id: ");
            //    int brandid = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Price: ");
            //    int price = int.Parse(Console.ReadLine());
            //    restService.Put(new Starship() { Id = id, Model = name, BrandId = brandid, WeaponId = weaponid, BasePrice = price }, tabblename);
            //}
            //else if (tabblename == "brand")
            //{
            //    Console.WriteLine("[Editing]\nType id here:");
            //    int id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Brand Name: ");
            //    string name = Console.ReadLine();
            //    restService.Put(new Brand() {Id = id, Name = name }, tabblename);
            //}
            //else if (tabblename == "weapon")
            //{
            //    Console.WriteLine("[Editing]\nType id here:");
            //    int id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Weapon Name: ");
            //    string name = Console.ReadLine();
            //    restService.Post(new Weapon () {Id = id, Name = name }, tabblename);
            //}
            //else
            //{
            //    throw new ArgumentException("There is no table with that name");

            //}

        }
        static void MenuRemoveItem(RestService restService)
        {
            Console.WriteLine("\nGive the name of the table: (starship,brand,weapon)");
            string tabblename = Console.ReadLine();
            Console.WriteLine("\nType the id of the item you want to remove");
            int id = int.Parse(Console.ReadLine());
            restService.Delete(id, tabblename);
        }
        static string ListItems(RestService restService) 
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
            return data_;
        }
    }
}
