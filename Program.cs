using GameShop.Data;
using GameShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Console;

namespace GameShop
{
    class Program
    {
        static GameShopsContext context = new GameShopsContext();
        static void Main(string[] args)
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                WriteLine("1. Registrera kund");
                WriteLine("2. Visa kundregistret");
                WriteLine("3. Skapa order");
                WriteLine("4. Lista order för kund");
                WriteLine("5. Registrera Artikel");
                WriteLine("6. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);
                Clear();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        RegisterCustomer();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DisplayCustomerRegistry();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CreateOrder();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        DisplayOrdersForCustomer();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        RegisteraArticle();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        shouldExit = true;
                        break;
                }
                Clear();
            }

        }

        private static void RegisteraArticle()
        {
            bool isCorrect = false;
            do
            {
                Clear();
                Write("Artikelnr: ");
                string articleNumber = ReadLine();
                Write("Namn: ");
                string name = ReadLine();
                Write("Beskrivning: ");
                string description = ReadLine();
                Write("Pris: ");
                decimal price = decimal.Parse(ReadLine());
                
                WriteLine();
                WriteLine("Är detta korrekt? (J)a eller (N)ej");
                ConsoleKeyInfo keyPressed;
                bool isValidKey = false;
                do
                {
                    keyPressed = ReadKey(true);
                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;
                } while (!isValidKey);
                if (keyPressed.Key == ConsoleKey.J)
                {
                    isCorrect = true;
                    Clear();
                    //context.Customer.Any(x => x.SocialSecurityNumber == socialSecurityNumber)
                    if (context.Article.Any(x => x.ArticleNumber == articleNumber))
                    {
                        WriteLine("Artikel finns redan");
                    }
                    else
                    {
                        Article article = new Article(articleNumber, name, description, price);

                        context.Article.Add(article);
                        context.SaveChanges();
                        WriteLine("Artikle registerad");
                    }

                    Thread.Sleep(2000);
                    Clear();

                }
            } while (!isCorrect);
        }

        private static void DisplayOrdersForCustomer()
        {
            Write("Kund (personr.): ");
            string socialSecurityNumber = ReadLine();
            Customer customer = context.Customer
                .Include(x => x.Address)
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderArticles)
                .ThenInclude(x => x.Article)
                .FirstOrDefault(customer => customer.SocialSecurityNumber == socialSecurityNumber);

             
            Clear();
            if (customer != null)
            {
                // visa kund och ordrar
                WriteLine($"{customer.FirstName} {customer.LastName}");
                WriteLine($"{customer.SocialSecurityNumber}");
                WriteLine();
                Write($"{customer.Address.Street}, {customer.Address.Postcode} {customer.Address.City}");
                WriteLine();
                foreach(Order order in customer.Orders)
                {
                    WriteLine("---------------------------------------------------------");

                    Write($"Order Id: {order.Id}");
                    WriteLine($"Datum: {order.CreatedAt}");
                    WriteLine("Artiklar");

                    foreach (OrderArticle orderArticle in order.OrderArticles)
                    {
                        WriteLine(orderArticle.Article.Name);
                    }
                }
               
                
                ConsoleKeyInfo keyPressed;
                bool escapePressed = false;
                do
                {
                    keyPressed = ReadKey(true);
                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        escapePressed = true;
                    }
                } while (!escapePressed);
            }
            else
            {
                WriteLine("Kund hittades ej");
                Thread.Sleep(2000);
            }
        }

        private static void CreateOrder()
        {
            Write("Kund (personr.): ");
            string socialSecurityNumber = ReadLine();
            
            Customer customer = context.Customer
                .FirstOrDefault(customer => customer.SocialSecurityNumber == socialSecurityNumber);

            Clear();
            Order order = new Order();
            bool orderCreated = false;

            if (customer != null)
            {
                do
                {
                    Clear();
                    WriteLine($"{customer.FirstName} {customer.LastName}");
                    WriteLine();

                    WriteLine("Artikel");
                    WriteLine("----------------------------------------------");
                    foreach (OrderArticle orderArticle in order.OrderArticles)
                    {
                        WriteLine(orderArticle.Article.Name);
                    }

                    Write("(L)ägg till");
                    Write("(S)kapa order");
                    ConsoleKeyInfo keyPressed= ReadKey(true);

                    Clear();

                    switch (keyPressed.Key)
                    {
                        //Add article
                        case ConsoleKey.L:
                            WriteLine("Obs! lägg inte till mer än en artikel av en viss typ");
                            WriteLine();
                            Write("Art.nr: ");
                                string articleNumber = ReadLine();
                            Article article = context.Article.FirstOrDefault(x => x.ArticleNumber == articleNumber);
                            OrderArticle orderArticle = new OrderArticle(article);
                            order.OrderArticles.Add(orderArticle);
                            context.SaveChanges();

                            break;

                        //Add order
                        case ConsoleKey.S:

                            customer.Orders.Add(order);
                            context.SaveChanges();
                            orderCreated = true;
                            break;

                    }
                }while (!orderCreated);
                Clear();
                WriteLine("Order created");

            }
            else
            {
                WriteLine("Kund hittades ej");
            }
            Thread.Sleep(2000);
        }

        private static void DisplayCustomerRegistry()
        {
            List<Customer> customerList = context.Customer.Include(x => x.Address).ToList();

            Write("Namn".PadRight(25, ' '));
            WriteLine("Adress");
            WriteLine("------------------------------------------------");

            foreach (Customer customer in customerList)
            {
                Write($"{customer.FirstName} {customer.LastName}, {customer.SocialSecurityNumber}".PadRight(25, ' '));
                     WriteLine($"{ customer.Address.Street},{customer.Address.Postcode}{customer.Address.City} ") ;
            }

            ConsoleKeyInfo keyPressed;
            bool escapePressed = false;
            do
            {
                keyPressed = ReadKey(true);
                if ( keyPressed.Key == ConsoleKey.Escape )
                {
                    escapePressed = true;
                }
            } while ( !escapePressed );

            
        }

        private static void RegisterCustomer()
        {
            
                bool isCorrect = false;
                do
                {
                    Clear();
                    Write("Förnamn: ");
                    string firstName = ReadLine();
                    Write("Efternamn: ");
                    string lastName = ReadLine();
                    Write("Personnummer: ");
                    string socialSecurityNumber = ReadLine();
                    Write("Gata: ");
                    string street = ReadLine();
                    Write("Ort: ");
                    string city = ReadLine();
                    Write("Postnummer: ");
                    string postcode = ReadLine();
                    WriteLine();
                    WriteLine("Är detta korrekt? (J)a eller (N)ej");
                    ConsoleKeyInfo keyPressed;
                    bool isValidKey = false;
                    do
                    {
                        keyPressed = ReadKey(true);
                        isValidKey = keyPressed.Key == ConsoleKey.J ||
                                     keyPressed.Key == ConsoleKey.N;
                    } while (!isValidKey);
                    if (keyPressed.Key == ConsoleKey.J)
                    {
                        //context.Customer.Any(x => x.SocialSecurityNumber == socialSecurityNumber)
                        if (context.Customer.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber) != null)
                        {
                            WriteLine("Kund finns redan");
                        }
                        else
                        {
                            Address address = new Address(street, city, postcode);
                            Customer customer = new Customer(firstName, lastName, socialSecurityNumber, address);

                        //SaveCustomer(customer);
                        context.Customer.Add(customer);
                        context.SaveChanges();

                        WriteLine("Kund registerad");
                        }

                        Thread.Sleep(2000);
                        Clear();
                       
                        isCorrect = true;
                    }
                } while (!isCorrect);
            
        }

        //private static void SaveCustomer(Customer customer)
        //{
        //    // Börja med att lägga till en customer till DbContext.
        //    // Vid detta skedet har vi inte ännu kommunicerat med databasen.
        //    context.Customer.Add(customer);

        //    // Nu sparar vi customer till databasen.
        //    context.SaveChanges();
        //}
    }
    
}
