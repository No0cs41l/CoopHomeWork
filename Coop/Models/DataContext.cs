using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Coop.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base()
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=;Password=0558;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssortimentProduct>().HasKey(ap => new { ap.AssortmentId, ap.ProductId });

            modelBuilder.Entity<AssortimentProduct>()
            .HasOne<Product>(ap => ap.Product)
            .WithMany(ap => ap.AssortimentProducts)
            .HasForeignKey(ap => ap.AssortmentId);

            modelBuilder.Entity<AssortimentProduct>()
            .HasOne<Assortment>(ap => ap.Assortment)
            .WithMany(ap => ap.AssortimentProducts)
            .HasForeignKey(ap => ap.AssortmentId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Assortment> Assortments { get; set; }
        public DbSet<AssortimentProduct> AssortimentProducts { get; set; }


        public IEnumerable<AssortimentProduct> GetAllAssortimentProduct()
        {
            return this.AssortimentProducts.Select(x => new AssortimentProduct {Assortment = this.Assortments.First(u => u.Id == x.AssortmentId), Product = this.Products.First(u => u.Id == x.ProductId), ProductId = x.ProductId,  AssortmentId = x.AssortmentId});     
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.Products;
        }

        public IEnumerable<Assortment> GetAllAssortments()
        {
            //return this.AssortimentProducts.Select(x => new AssortimentProduct { Assortment = this.Assortments.First(u => u.Id == x.AssortmentId), Product = this.Products.First(u => u.Id == x.ProductId), ProductId = x.ProductId, AssortmentId = x.AssortmentId });
            return this.Assortments;
        }

        public Product FindProductById(int id)
        {
            var item = this.Products.Where(x => x.Id == id).Select(x => x).First();
            return item;
        }
        public Assortment FindAssortmentById(int id)
        {
            var item = this.Assortments.Where(x => x.Id == id).Select(x => x).First();
            return item;

        }

        public AssortimentProduct GetAllProducts111(int id)
        {
            var item = this.AssortimentProducts.Select(x => new AssortimentProduct { Assortment = this.Assortments.First(u => u.Id == x.AssortmentId), Product = this.Products.First(u => u.Id == x.ProductId), ProductId = x.ProductId, AssortmentId = x.AssortmentId }).Where(x => x.ProductId == id).First();
            return item;
        }

        public IEnumerable<Assortment> GetAllAssortiment()
        {
            var item = this.Assortments.ToList();
            return item;
        }

    }

}
