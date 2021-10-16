using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNJXL9_HFT_2021221.Data
{
    public partial class StarshipDbContext : DbContext
    {
        //Help with writing modify
        //https://www.learnentityframeworkcore.com/dbcontext/modifying-data
        // Tables
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }
        public virtual DbSet<Starship> Starships { get; set; }


        public StarshipDbContext()
        {
            // creating the neccessary elements to get the database
            this.Database.EnsureCreated();
        }

        public StarshipDbContext(DbContextOptions<StarshipDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StarshipDb.mdf;Integrated Security=True";
                optionsBuilder.
                    UseLazyLoadingProxies().UseSqlServer(s);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Starship>(entity =>
            {
                entity.HasOne(starship => starship.Brand)
                    .WithMany(brand => brand.Starships)
                    .HasForeignKey(starship => starship.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                
            });
            modelBuilder.Entity<Starship>(entity =>
            {
                entity.HasOne(starship => starship.Weapon)
                    .WithMany(weapon => weapon.Starships)
                    .HasForeignKey(starship => starship.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            DbSeed db = new DbSeed();
            foreach (var item in DbSeed.brands)
            {                
                modelBuilder.Entity<Brand>().HasData(item);
            }
            foreach (var item in DbSeed.weapons)
            {
                modelBuilder.Entity<Weapon>().HasData(item);
            }
            foreach (var item in DbSeed.starships)
            {
                modelBuilder.Entity<Starship>().HasData(item);
            }

        }
    }
}
