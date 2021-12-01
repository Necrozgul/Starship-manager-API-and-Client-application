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
    public class BrandRepository : IBrandRepository
    {
        XYZDbContext db;
        public BrandRepository(XYZDbContext db)
        {
            this.db = db;
        }

        public Brand Read(int id)
        {
            return db.Brands.FirstOrDefault(t => t.Id == id);
        }
        public void Create(Brand obj)
        {
            db.Brands.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Brand obj)
        {
            
            var oldbrand = Read(obj.Id);
            oldbrand.Name = obj.Name;
            db.SaveChanges();
        }

        public IQueryable<Brand> ReadAll()
        {
            return db.Brands;
        }
    }
}
