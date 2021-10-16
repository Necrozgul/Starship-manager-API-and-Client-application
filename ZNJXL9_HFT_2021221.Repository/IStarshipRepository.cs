using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IStarshipRepository : IRepository<Starship>
    {
        void Update(int id, string modelName, int newPrice, int weaponid, int Brandid);
        void Delete(int id);
        void Create(string modelName, int newPrice, int brandid, int weaponid);
    }

}
