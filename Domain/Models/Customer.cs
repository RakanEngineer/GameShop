using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models
{
    class Customer
    {
        //public Customer()
        //{

        //}

        //public int Id { get; protected set; }
        //public string FirstName { get; protected set; }
        //public string LastName { get; protected set; }
        //public string SocialSecurityNumber { get; protected set; }
        //public Address Address { get; protected set; }
        //public List<Order> Orders { get; protected set; } = new List<Order>();

        //public Customer(string firstName, string lastName, string socialSecurityNumber, Address address)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    SocialSecurityNumber = socialSecurityNumber;
        //    Address = address;
        //}
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string SocialSecurityNumber { get; protected set; }
        // TODO kola om finns attribut för att förhindra binding
        public Address Address { get; protected set; }
        //public List<Order> Orders { get; protected set; } = new List<Order>();

        public Customer(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Customer(string firstName, string lastName, string socialSecurityNumber, Address address)
            : this(firstName, lastName, socialSecurityNumber)
        {
            Address = address;
        }
    }
}
