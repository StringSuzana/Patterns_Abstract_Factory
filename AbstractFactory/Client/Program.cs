using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var server = new Server(logger);
            Console.WriteLine("Choose shop:");
            Console.WriteLine("Enter W for WestShop, E for EastShop and B for both");
            var input = Console.ReadLine();
            List<IProductFactory> factories_selected = new List<IProductFactory>();

            switch (input.ToUpper())
            {
                case "W":
                    factories_selected.Add(new WestFactory());
                    break;

                case "E":
                    factories_selected.Add(new EastFactory());
                    break;
                case "B":
                    factories_selected.Add(new WestFactory());
                    factories_selected.Add(new EastFactory());
                    break;
                default:
                    Console.WriteLine("Wrong selection.");
                    Console.Beep(3276, 500);
                    break;
            }

            if (factories_selected.Count > 0)
                new Client(server, logger, factories_selected).Start();
        }
    }
}
