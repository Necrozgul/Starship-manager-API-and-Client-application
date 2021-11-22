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
    //CRUD : Create, Read, ReadAll, Update, Delete
    public class StarshipRepository :
        Repository<Starship>, IStarshipRepository
    {
        public StarshipRepository(DbContext ctx) : base(ctx) { }

        public override Starship GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Create(Starship obj)
        {
            var context = new XYZDbContext();
            var s = new Starship
            {
                Model = obj.Model,
                BasePrice = obj.BasePrice,
                WeaponId = obj.WeaponId,
                BrandId = obj.BrandId
            };
            context.Add(s);
            context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var x = GetOne(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            ctx.Remove(x);
            ctx.SaveChanges();
        }

        public override void Update(Starship obj)
        {
            var s = GetOne(obj.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            s.BasePrice = obj.BasePrice;
            s.Model = obj.Model;
            s.BrandId = obj.BrandId;
            s.WeaponId = obj.WeaponId;
            ctx.SaveChanges();
        }
    }
}
