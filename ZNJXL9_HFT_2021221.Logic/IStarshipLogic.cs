using System;
using System.Collections.Generic;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Logic
{
    public interface IStarshipLogic
    {
        Starship Read(int id);
        IEnumerable<Starship> ReadAll();
        void Create(Starship obj);
        void Update(Starship obj);
        void Delete(int id);

        //NON CRUD Methods (5)
        IList<AveragesResult> GetModelAverages();
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByModels();
        Starship MostExpensiveStarship();
        Starship CheapestStarship();
        //Starship StarShipSearcher(int id, string brandname, string weaponname);




    }
}
