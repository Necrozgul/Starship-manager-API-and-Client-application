using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    //Crud: Create, Read, ReadAll, Update, Delete
    public class BrandRepository :
        Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }

        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Create(Brand obj)
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
                    "Brand not found"
                );
            }
            ctx.Remove(x);
            ctx.SaveChanges();
        }

        public override void Update(Brand obj)
        {
            var s = GetOne(obj.Id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Brand not found"
                );
            }
            s.Name = obj.Name;
            ctx.SaveChanges();
        }

    }
}
