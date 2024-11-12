using static System.Console;

namespace GameShop
{
    internal class Program
    {
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
                        CreateOrder();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        DisplayAccountsForCustomer();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        shouldExit = true;
                        break;
                }
                Clear();
            }

        }

        private static void RegisterCustomer()
        {
            throw new NotImplementedException();
        }
    }
    }
}
