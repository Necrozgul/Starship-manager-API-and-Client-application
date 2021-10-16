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

        public void ChangeName(int id, string newName)
        {
            var s = Read(id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Car not found"
                );
            }
            s.Name = newName;
            // Unit of Work pattern ???
            ctx.SaveChanges();
        }
    }
}
