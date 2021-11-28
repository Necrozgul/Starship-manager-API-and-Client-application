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
    public class WeaponRepository : IWeaponRepository
    {
        XYZDbContext db;
        public WeaponRepository(XYZDbContext db)
        {
            this.db = db;
        }

        public Weapon Read(int id)
        {
            return db.Weapons.FirstOrDefault(t => t.Id == id);
        }
        public void Create(Weapon obj)
        {
            db.Weapons.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Weapon obj)
        {
            var oldbrand = Read(obj.Id);
            oldbrand.Name = obj.Name;
            db.SaveChanges();
        }

        public IQueryable<Weapon> ReadAll()
        {
            return db.Weapons;
        }
    }
}
