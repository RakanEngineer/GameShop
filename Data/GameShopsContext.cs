using GameShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Data
{
    class GameShopsContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Article> Article { get; set; }

        //public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GameShop;Integrated Security=true; Encrypt=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<OrderArticle>().HasKey(bc => new { bc.OrderId,bc.ArticleId});

           modelBuilder.Entity<OrderArticle>().HasOne(bc => bc.Article).WithMany(c => c.OrderArticles).HasForeignKey(bc => bc.ArticleId);

            modelBuilder.Entity<OrderArticle>().HasOne(bc => bc.Order).WithMany(c => c.OrderArticles).HasForeignKey(bc => bc.OrderId);

        }
    }
}
