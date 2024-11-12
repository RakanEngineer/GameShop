using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    public class Order
    {
        public int Id { get; protected set; }
        public string Product { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public int CustomerId { get; protected set; }
        //public Customer Customer { get; protected set; }

        public Order(string product)
        {
            Product = product;
            CreatedAt = DateTime.Now;

        }
        //public int Id { get; protected set; }
        //public string Product { get; protected set; }
        //public DateTime CreatedAt { get; protected set; }
        //public int CustomerId { get; protected set; }
        //public Customer Customer { get; protected set; }
        //public Order(string product)
        //{
        //    Product = product;
        //    CreatedAt = DateTime.Now;
        //}
        //public Order(string product, Customer customer)
        //    : this(product)
        //{
        //    Customer = customer;
        //}
    }
}
