using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Logic
{
    interface IWeaponLogic
    {
        Weapon GetOne(int id);
        IList<Weapon> GetAll();
        void Create(Weapon obj);
        void Update(Weapon obj);
        void Delete(int id);

        //NON CRUD Methods (5)
    }
}
