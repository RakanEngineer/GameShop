using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    class Order
    {
        public int Id { get; protected set; }
        //public string Article { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public int CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
        public List<OrderArticle> OrderArticles { get; protected set; }= new List<OrderArticle>();

        public Order()
        {
            CreatedAt = DateTime.Now;

        }

    }
}
