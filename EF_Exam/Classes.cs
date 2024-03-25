using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EF_Exam
{
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackCount { get; set; }
        public int? BandId { get; set; }
        public Band? Band { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int PublishingYear { get; set; }
        public decimal SelfCoast { get; set; }
        public decimal Price { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SoldCount { get; set; }
        public bool IsSold { get; set; }
    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Plate> Plates { get; set; } = new();
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
        public virtual List<Plate> Plates { get; set; } = new();
    }
    public class Band
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public virtual List<Plate> Plates { get; set; } = new();
    }
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "NoNameCustomer";
        public string LastName { get; set; }
        public decimal SpentMoney { get; set; }
        public double DiscountPercent { get; set; } = 0;
        [NotMapped]
        private string login;
        [NotMapped]
        public string Login { get { return login; } set { login = value; } }
        [NotMapped]
        private string password;
        [NotMapped]
        public string Password { get { return password; } set { password = value; } }
        public Customer() { }
        public Customer(string l, string p) { login = l; password = p; }
    }
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PromotionDiscount { get; set; }
    }

    public class PlateStore : DbContext
    {
        public virtual DbSet<Plate> Plates { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public PlateStore() : base() { Database.EnsureDeleted(); Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=MusicStore;integrated security=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plate>()
                .Property(x => x.CustomerId)
                .HasColumnName("ReservedForCustomer");

            modelBuilder.Entity<Plate>()
                .HasOne(x => x.Band)
                .WithMany(x => x.Plates)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Plate>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Plates)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Plate>()
                .HasOne(x => x.Publisher)
                .WithMany(x => x.Plates)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Plate>()
                .HasOne(x => x.Publisher)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Genre>()
                .HasOne(x => x.Promotion)
                .WithMany()
                .HasForeignKey(x => x.PromotionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Band>()
                .HasOne(x => x.Genre)
                .WithMany()
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
