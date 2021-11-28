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
    public class StarshipRepository : IStarshipRepository
    {

        XYZDbContext db;
        public StarshipRepository(XYZDbContext db)
        {
            this.db = db;  
        }

        public Starship Read(int id)
        {
            return db.Starships.FirstOrDefault(t => t.Id == id);
        }

        public void Create(Starship obj)
        {
            var context = new XYZDbContext();
            var s = new Starship
            {
                Id = obj.Id, //Ez a rész lehet felesleges
                Model = obj.Model,
                BasePrice = obj.BasePrice,
                WeaponId = obj.WeaponId,
                BrandId = obj.BrandId
            };
            context.Add(s);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            if (x == null)
            {
                throw new InvalidOperationException(
                    "Starship not found"
                );
            }
            db.Remove(x);
            db.SaveChanges();
        }

        public void Update(Starship obj)
        {
            var s = Read(obj.Id);
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
            db.SaveChanges();
        }

        public IQueryable<Starship> ReadAll()
        {
            return db.Starships;
        }
    }
}
