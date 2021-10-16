using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

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

        public void Update(string modelName, int id, int newPrice, int weaponid, int Brandid)
        {
            var s = GetOne(id);
            if (s == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            s.BasePrice = newPrice;
            s.Model = modelName;
            s.BrandId = Brandid;
            s.WeaponId = weaponid;
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
        public void Create(string modelName, int id, int newPrice, int weaponid)
        {
            throw new NotImplementedException();
        }
    }
}
