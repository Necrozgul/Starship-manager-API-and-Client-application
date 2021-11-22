using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Logic
{
    public interface IBrandLogic
    {

        Brand GetOne(int id);
        IEnumerable<Brand> GetAll();
        void Create(Brand obj);
        void Update(Brand obj);
        void Delete(int id);
        Brand MostUsedBrand();

        
        
    }
}
