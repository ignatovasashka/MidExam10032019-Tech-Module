using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPerKilometer = double.Parse(Console.ReadLine());
            double foodExpensesPerPersonPerDay = double.Parse(Console.ReadLine());
            double pricePerRoomPerPersonPerNight = double.Parse(Console.ReadLine());

            double totalFuelConsumed = 0;
            double totalFoodExpenses = people * foodExpensesPerPersonPerDay * days;
            double totalHotelExpenses = people * pricePerRoomPerPersonPerNight * days;

            if (people > 10)
            {
                pricePerRoomPerPersonPerNight = pricePerRoomPerPersonPerNight * 0.75;
            }

            double currentExpenses = 0;

            while (currentExpenses <= budget)
            {
                for (int i = 1; i <= days; i++)
                {
                    double traveledKmPerDay = double.Parse(Console.ReadLine());

                    totalFuelConsumed += traveledKmPerDay * fuelPerKilometer;
                    currentExpenses += totalFuelConsumed;

                    currentExpenses += pricePerRoomPerPersonPerNight * people;
                    currentExpenses += foodExpensesPerPersonPerDay * people;

                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        currentExpenses += currentExpenses * 0.4;
                    }
                    if (i % 7 == 0)
                    {
                        currentExpenses -= currentExpenses / people;
                    }

                }
            }

            currentExpenses -= pricePerRoomPerPersonPerNight * people;

            //Console.WriteLine("-->" + currentExpenses);

            if (currentExpenses > budget)
            {
                double moneyNeeded = currentExpenses - budget;
                Console.WriteLine($"Not enough money to continue the trip. You need {moneyNeeded:f2}$ more.");
            }
            else
            {
                double moneyLeft = budget - currentExpenses;
                Console.WriteLine($"You have reached the destination. You have {moneyLeft:f2}$ budget left.");
            }

            
            
        }
    }
}
