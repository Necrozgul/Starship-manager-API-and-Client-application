using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    public class WeaponRepository :
        Repository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(DbContext ctx) : base(ctx) { }

        public override Weapon Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public void ChangeName(int id, string newName)
        {
            var car = Read(id);
            if (car == null)
            {
                throw new InvalidOperationException(
                    "Car not found"
                );
            }
            car.Name = newName;
            // Unit of Work pattern ???
            ctx.SaveChanges();
        }
    }
}
