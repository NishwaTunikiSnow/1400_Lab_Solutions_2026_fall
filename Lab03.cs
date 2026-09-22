// Name: [Your Name]
// Lab: Coffee Shop Order System - Loops and One-Dimensional Arrays
// Date: [Submission Date]

using System;

class Program
{
    static void PrintMenu(string[] menuItems, double[] menuPrices)
    {
        Console.WriteLine("Menu");
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i],-12} {menuPrices[i]:C}");
        }
    }

    static void Main()
    {
        string[] menuItems = { "Espresso", "Latte", "Cappuccino", "Mocha", "Drip Coffee", "Iced Tea" };
        double[] menuPrices = { 2.50, 4.00, 3.75, 4.50, 2.00, 2.75 };

        const int orderCapacity = 10;
        const double taxRate = 0.07;

        string playAgain = "y";

        Console.WriteLine("Welcome to the Coffee Shop!");

        // Unknown number of orders ahead of time, so this uses a while loop.
        while (playAgain == "y")
        {
            Console.WriteLine();
            PrintMenu(menuItems, menuPrices);

            int[] orderedItemIndex = new int[orderCapacity];
            int[] orderedQuantity = new int[orderCapacity];
            int lineCount = 0;

            // Sentinel-controlled while loop: keep taking items until the
            // customer enters 0 or the order runs out of room.
            while (lineCount < orderCapacity)
            {
                Console.Write("\nEnter item number (or 0 to finish): ");
                int itemNumber = int.Parse(Console.ReadLine());

                if (itemNumber == 0)
                {
                    break;
                }

                int itemIndex = itemNumber - 1; // menu numbers are 1-based, arrays are 0-based

                if (itemIndex < 0 || itemIndex >= menuItems.Length)
                {
                    Console.WriteLine("That's not a valid item number. Try again.");
                    continue;
                }

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                orderedItemIndex[lineCount] = itemIndex;
                orderedQuantity[lineCount] = quantity;
                lineCount++;
            }

            Console.WriteLine("\nReceipt");

            double subtotal = 0;
            double highestTotal = double.MinValue;
            double lowestTotal = double.MaxValue;
            int highestIndex = -1;
            int lowestIndex = -1;

            for (int i = 0; i < lineCount; i++)
            {
                int itemIndex = orderedItemIndex[i];
                int quantity = orderedQuantity[i];
                double lineTotal = menuPrices[itemIndex] * quantity;

                Console.WriteLine($"{menuItems[itemIndex],-12} x{quantity,-3} {lineTotal:C}");

                subtotal += lineTotal;

                if (lineTotal > highestTotal)
                {
                    highestTotal = lineTotal;
                    highestIndex = i;
                }

                if (lineTotal < lowestTotal)
                {
                    lowestTotal = lineTotal;
                    lowestIndex = i;
                }
            }

            double tax = subtotal * taxRate;
            double total = subtotal + tax;

            Console.WriteLine();
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Tax ({taxRate:P0}): {tax:C}");
            Console.WriteLine($"Total:    {total:C}");

            if (lineCount > 0)
            {
                string biggestName = menuItems[orderedItemIndex[highestIndex]];
                string smallestName = menuItems[orderedItemIndex[lowestIndex]];

                Console.WriteLine();
                Console.WriteLine($"Biggest line item:  {biggestName} ({highestTotal:C})");
                Console.WriteLine($"Smallest line item: {smallestName} ({lowestTotal:C})");
            }

            Console.Write("\nStart another order? (y/n): ");
            playAgain = Console.ReadLine().Trim().ToLower();
        }

        Console.WriteLine("\nGoodbye!");
    }
}
