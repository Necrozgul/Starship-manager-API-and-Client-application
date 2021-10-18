using System;
using System.Collections.Generic;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Logic
{
    public interface IStarshipLogic
    {
        //CRUD Methods
        Starship GetOne(int id);
        IList<Starship> GetAll();
        void Create(Starship obj);
        void Update(Starship obj);
        void Delete(int id);

        //NON CRUD Methods (5)
        IList<AveragesResult> GetBrandAverages();
        double AVGPrice();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
    }
}
