using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Repository
{
    public class WeaponRepository :
        Repository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(DbContext ctx) : base(ctx) { }

        public override Weapon GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Create(Weapon obj)
        {
            ctx.Add(obj);
            ctx.SaveChanges();
        }

        public override void Delete(int id)
        {
            var x = GetOne(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Weapon not found"
                );
            }
            ctx.Remove(x);
            ctx.SaveChanges();
        }

        public override void Update(Weapon obj)
        {
            var s = GetOne(obj.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Weapon not found"
                );
            }
            s.Name = obj.Name;
            s.Id = obj.Id;
            ctx.SaveChanges();
        }
    }
}
