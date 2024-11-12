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
                WriteLine("2. Visa kundregister");
                WriteLine("3. Skapa order");
                WriteLine("4. Lista konton för kund");
                WriteLine("5. Avsluta");
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
                        //CreateOrder();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //DisplayAccountsForCustomer();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        shouldExit = true;
                        break;
                }
                Clear();
            }

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

                            SaveCustomer(customer);
                            WriteLine("Kund registerad");
                        }


                        Clear();

                        Thread.Sleep(2000);
                        isCorrect = true;
                    }
                } while (!isCorrect);
            }
        }

        private static void SaveCustomer(Customer customer)
        {
            // Börja med att lägga till en customer till DbContext.
            // Vid detta skedet har vi inte ännu kommunicerat med databasen.
            context.Customer.Add(customer);

            // Nu sparar vi customer till databasen.
            context.SaveChanges();
        }
    }
    
}
