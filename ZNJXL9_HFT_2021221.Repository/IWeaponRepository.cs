﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IWeaponRepository : IRepository<Weapon>
    {
        void ChangeName(int id, string newName);
    }
}
