using System;
using System.Collections.Generic;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Logic
{
    public interface IStarshipLogic
    {
        Starship GetOne(int id);

        void Update(int id, Starship obj);

        IList<Starship> GetAll();

        //IList<AveragesResult> GetBrandAverages();

        double AVGPrice();

        void Create(Starship obj);

        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
    }
}
