using Microsoft.EntityFrameworkCore;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Data
{
    public partial class XYZDbContext : DbContext
    {
        public virtual DbSet<Starship> Starships { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        

        public XYZDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StarshipDB.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Starship>(entity =>
            {
                entity.HasOne(starship => starship.Brand)
                    .WithMany(brand => brand.Starships)
                    .HasForeignKey(starship => starship.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    ;
                entity.HasOne(starship => starship.Weapon)
                    .WithMany(weapon => weapon.Starships)
                    .HasForeignKey(starship => starship.WeaponId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Brand cec = new Brand() { Id = 1, Name = "CEC" };
            Brand cygnus = new Brand() { Id = 2, Name = "Cygnus" };
            Brand kuat = new Brand() { Id = 3, Name = "Kuat" };

            Weapon Turbolaser = new Weapon() { Id = 1, Name = "Turbo Laser" };
            Weapon Flacgun = new Weapon() { Id = 2, Name = "Flac Gun" };
            Weapon Protonbeambannon = new Weapon() { Id = 3, Name = "Proton Beam Cannon" };
            Weapon Orbitalautocannon = new Weapon() { Id = 4, Name = "Orbital Cannon" };

            Starship kuatEclipse = new Starship() { Id = 1, BrandId = kuat.Id, BasePrice = 200, Model = "Eclipse", WeaponId = Orbitalautocannon.Id };
            Starship kuatExecutor = new Starship() { Id = 2, BrandId = kuat.Id, BasePrice = 30, Model = "Executor", WeaponId = Orbitalautocannon.Id };
            Starship cecYV666 = new Starship() { Id = 3, BrandId = cec.Id, BasePrice = 100, Model = "YV-666", WeaponId = Turbolaser.Id };
            Starship cecVCX100 = new Starship() { Id = 4, BrandId = cec.Id, BasePrice = 150, Model = "VCX-150", WeaponId = Turbolaser.Id };
            Starship cygnusXwing = new Starship() { Id = 5, BrandId = cygnus.Id, BasePrice = 20, Model = "XWing", WeaponId = Flacgun.Id };
            Starship cygnusT4a = new Starship() { Id = 6, BrandId = cygnus.Id, BasePrice = 250, Model = "T-4A", WeaponId = Turbolaser.Id };

            mb.Entity<Starship>().HasData(kuatEclipse, kuatExecutor, cecYV666, cecVCX100, cygnusXwing, cygnusT4a);
            mb.Entity<Brand>().HasData(cec,cygnus,kuat);
            mb.Entity<Weapon>().HasData(Turbolaser,Flacgun,Protonbeambannon,Orbitalautocannon);
            
            
        }
    }
}
