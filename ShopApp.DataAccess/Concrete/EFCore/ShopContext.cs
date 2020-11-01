using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EFCore
{
    public class ShopContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=ShopDb;integrated security=true;");
        }
        /// <summary>
        /// ProductCategory classının birincil anahtarı 2 tane olacakğından bu kısıma 
        /// Fluent API yazıyoruz. Ki bağlanan iki tablonun id alanları da PK olsun.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(x => new { x.CategoryId, x.ProductId });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
