// SOLUTION - Lab 6: Library Book Finder (Linear Search and Binary Search)

using System;

public class Program
{
    // Book IDs are in SORTED order (smallest to largest)
    static int[] bookIds =
    {
        101, 104, 109, 115, 122, 130, 141, 157, 168
    };

    // Book titles (same position as bookIds)
    static string[] titles =
    {
        "Hatchet", "Wonder", "Holes", "Matilda", "The Giver",
        "Coraline", "Frindle", "Charlotte's Web", "Number the Stars"
    };

    public static void Main()
    {
        string choice;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Library Book Finder");
            Console.WriteLine("1. Find a book by name");
            Console.WriteLine("2. Find a book by ID");
            Console.WriteLine("0. Quit");
            Console.Write("Choose: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Book name: ");
                string name = Console.ReadLine();

                int index = FindBookByName(titles, name);

                if (index == -1)
                {
                    Console.WriteLine(name + " is not in the library.");
                }
                else
                {
                    Console.WriteLine(titles[index] + " has ID " + bookIds[index] + ".");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Book ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                int index = FindBookById(bookIds, id);

                if (index == -1)
                {
                    Console.WriteLine("No book has ID " + id + ".");
                }
                else
                {
                    Console.WriteLine("Book " + id + " is " + titles[index] + ".");
                }
            }

        } while (choice != "0");

        Console.WriteLine("Goodbye!");
    }

    // =========================================================
    //  SEARCH METHODS (solution)
    // =========================================================

    // 1. LINEAR SEARCH
    //    Use a for loop to check each title.
    //    Upper or lower case should not matter:
    //    "holes", "HOLES" and "Holes" all find Holes.
    //    Hint: compare titles[i].ToLower() with name.ToLower()
    //    Also count the steps: add 1 to a counter each time
    //    you check titles[i]. Before you return, print it:
    //    Console.WriteLine("Steps: " + steps);
    //    Return the index if found, or -1 if not found.
    public static int FindBookByName(string[] titles, string name)
    {
        int steps = 0;

        for (int i = 0; i < titles.Length; i++)
        {
            steps++;

            if (titles[i].ToLower() == name.ToLower())
            {
                Console.WriteLine("Steps: " + steps);
                return i;
            }
        }

        Console.WriteLine("Steps: " + steps);
        return -1;
    }

    // 2. BINARY SEARCH
    //    The ids array is sorted.
    //    Use low, mid and high, like in the slides.
    //    Also count the steps: add 1 to a counter each time
    //    you check ids[mid]. Before you return, print it:
    //    Console.WriteLine("Steps: " + steps);
    //    Return the index if found, or -1 if not found.
    public static int FindBookById(int[] ids, int id)
    {
        int low = 0;
        int high = ids.Length - 1;
        int steps = 0;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            steps++;

            if (ids[mid] == id)
            {
                Console.WriteLine("Steps: " + steps);
                return mid;
            }
            else if (ids[mid] < id)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        Console.WriteLine("Steps: " + steps);
        return -1;
    }
}
