using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Data
{
    public partial class XYZDbContext : DbContext
    {
        //Help with writing modify
        //https://www.learnentityframeworkcore.com/dbcontext/modifying-data
        // Tables
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<Starship> Starships { get; set; }


        public XYZDbContext()
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StarshipDb.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Starship>(entity =>
            {
                entity.HasOne(starship => starship.Brand)
                    .WithMany(brand => brand.Starships)
                    .HasForeignKey(starship => starship.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(starship => starship.Weapon)
                    .WithMany(weapon => weapon.Starships)
                    .HasForeignKey(starship => starship.WeaponId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            DbSeed db = new DbSeed();
            modelBuilder.Entity<Starship>().HasData(DbSeed.starships);
            modelBuilder.Entity<Brand>().HasData(DbSeed.brands);
            modelBuilder.Entity<Weapon>().HasData(DbSeed.weapons);
        }
    }
}
