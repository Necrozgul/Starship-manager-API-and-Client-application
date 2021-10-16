using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    //Crud: Create, Read, ReadAll, Update, Delete
    public class BrandRepository :
        Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext ctx) : base(ctx) { }

        public override Brand Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id, string name)
        {
            var s = Read(id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Brand not found"
                );
            }
            s.Name = name;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Brand not found"
                );
            }
            ctx.Remove(x);
            ctx.SaveChanges();
        }

        public void Create(string name)
        {
            var context = new XYZDbContext();
            var s = new Brand
            {
                Name = name
            };
            context.Add(s);
            context.SaveChanges();
        }
    }
}
