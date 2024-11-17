using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    class OrderArticle
    {
        public int OrderId { get; protected set; }
        public Order Order { get; protected set; }
        public int ArticleId { get; protected set; }
        public Article Article { get; protected set; }

        public OrderArticle(int orderId, int articleId)
        {
            OrderId = orderId;
            ArticleId = articleId;

        }

        public OrderArticle(Article? article)
        {
            Article = article;
        }
    }
}
