using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    public class Address
    {
        public int Id { get; protected set; }
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string Postcode { get; protected set; }
        public int CustomerId { get; protected set; }
        //public Customer Customer { get; protected set; }

        public Address(string street, string city, string postcode)
        {
            Street = street;
            City = city;
            Postcode = postcode;
        }
    }
}
