using System;
using System.Collections.Generic;
using System.Linq;

namespace _02HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split('|').ToList();
            double budget = double.Parse(Console.ReadLine());

            List<string> types = new List<string>();
            List<double> prices = new List<double>();
            List<double> newPrices = new List<double>();

            for (int i = 0; i < items.Count; i++)
            {
                List<string> currentItems = items[i].Split("->").ToList();
                
                    types.Add(currentItems[0]);
                    prices.Add(double.Parse(currentItems[1]));
                
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (IsPriceNotExeeded(types[i], prices[i]) && budget-prices[i] >= 0)
                {
                    budget -= prices[i];
                    newPrices.Add(prices[i]*1.4);
                }
            }

            for (int i = 0; i < newPrices.Count; i++)
            {
                Console.Write($"{newPrices[i]:f2} ");
            }
            Console.WriteLine();

            double profit = newPrices.Sum()-(newPrices.Sum()/1.4);

            Console.WriteLine($"Profit: {profit:f2}");

            budget += newPrices.Sum();

            if (budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }

        private static bool IsPriceNotExeeded(string item, double price)
        {

            double maxPrice = 0;

            switch (item)
            {
                case "Clothes": maxPrice = 50.0; break;
                case "Shoes": maxPrice = 35.0; break;
                case "Accessories": maxPrice = 20.5; break;
            }

            if (item == "Clothes" && price > maxPrice )
            {
                return false;
            }
            else if (item == "Shoes" && price > maxPrice)
            {
                return false;
            }
            else if (item == "Accessories" && price > maxPrice)
            {
                return false;
            }
            else
            {
                return true;
            }





        }
    }
}
