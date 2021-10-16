using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Repository
{
    public class StarshipRepository :
        Repository<Starship>, IStarshipRepository
    {
        public StarshipRepository(DbContext ctx) : base(ctx) { }

        public override Starship GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void ChangePrice(int id, int newPrice)
        {
            var car = GetOne(id);
            if (car == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            car.BasePrice = newPrice;
            // Unit of Work pattern ???
            ctx.SaveChanges();
        }
        public void ChangeName(int id, string newName)
        {
            var x = GetOne(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            x.Model = newName;
            ctx.SaveChanges();
        }
        public void Delete(int id)
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
        public void Modify()
        { 
        
        }
    }
}
