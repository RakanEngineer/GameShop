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
        public DbSet<Address> Address { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GameShopsOrders;Integrated Security=true; Encrypt=True;Trust Server Certificate=True");
        }
    }
}
