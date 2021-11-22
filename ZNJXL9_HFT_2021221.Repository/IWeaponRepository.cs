using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IWeaponRepository : IRepository<Weapon>
    {
        void Update(Weapon obj);
        void Delete(int id);
        void Create(Weapon obj);
    }
}
