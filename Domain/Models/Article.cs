using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    class Article
    {
        public int Id { get; protected set; }
        public string ArticleNumber { get; protected set; } 
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public List<OrderArticle> OrderArticles { get; protected set; } = new List<OrderArticle>();


        public Article(string articleNumber, string name, string description, decimal price)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
