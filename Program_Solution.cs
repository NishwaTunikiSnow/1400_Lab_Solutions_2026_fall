// SOLUTION - Lab 6: Library Book Finder (Linear Search and Binary Search)

using System;

public class Program
{
    // Books on the shelf, in no special order
    static string[] titles =
    {
        "Hatchet", "Wonder", "Holes",
        "Matilda", "The Giver", "Coraline"
    };

    // Page count for each book (same position as titles)
    static int[] pages =
    {
        192, 315, 233, 240, 180, 162
    };

    // Library card numbers are kept in SORTED order (smallest to largest)
    static int[] cardNumbers =
    {
        2001, 2004, 2009, 2015, 2022, 2030, 2041, 2057, 2068
    };

    public static void Main()
    {
        string choice;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Library Book Finder");
            Console.WriteLine("1. Find a book by title");
            Console.WriteLine("2. Find a book by page count");
            Console.WriteLine("3. Check a library card number");
            Console.WriteLine("4. Find the first book shorter than a page count");
            Console.WriteLine("0. Quit");
            Console.Write("Choose: ");

            choice = (Console.ReadLine() ?? "0").Trim();

            if (choice == "1")
            {
                FindBookByTitle();
            }
            else if (choice == "2")
            {
                FindBookByPages();
            }
            else if (choice == "3")
            {
                CheckCard();
            }
            else if (choice == "4")
            {
                FindShortBook();
            }
            else if (choice != "0")
            {
                Console.WriteLine("Please choose 0, 1, 2, 3 or 4.");
            }

        } while (choice != "0");

        Console.WriteLine("Goodbye!");
    }

    static void FindBookByTitle()
    {
        Console.Write("Book title: ");
        string title = Console.ReadLine() ?? "";

        int index = FindBook(titles, title);

        if (index == -1)
        {
            Console.WriteLine(title + " is not in the library.");
        }
        else
        {
            Console.WriteLine(
                titles[index] + " is on shelf spot " + index
                + " and has " + pages[index] + " pages.");
        }
    }

    static void FindBookByPages()
    {
        Console.Write("Number of pages: ");

        int number;

        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        int index = LinearSearch(pages, number);

        if (index == -1)
        {
            Console.WriteLine("No book has exactly " + number + " pages.");
        }
        else
        {
            Console.WriteLine(
                "The book with " + number + " pages is "
                + titles[index] + " (shelf spot " + index + ").");
        }
    }

    static void CheckCard()
    {
        Console.Write("Library card number: ");

        int number;

        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        int index = BinarySearch(cardNumbers, number);
        int steps = CountBinarySearchSteps(cardNumbers, number);

        if (index == -1)
        {
            Console.WriteLine(
                "Card " + number + " is not valid ("
                + steps + " comparisons).");
        }
        else
        {
            Console.WriteLine(
                "Card " + number + " is valid, found at index " + index
                + " (" + steps + " comparisons).");
        }
    }

    static void FindShortBook()
    {
        Console.Write("Fewer than how many pages? ");

        int maxPages;

        if (!int.TryParse(Console.ReadLine(), out maxPages))
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        int index = FindFirstShorterThan(pages, maxPages);

        if (index == -1)
        {
            Console.WriteLine("No book is that short.");
        }
        else
        {
            Console.WriteLine(
                "First book under " + maxPages + " pages: "
                + titles[index] + " (" + pages[index] + " pages)");
        }
    }

    // =========================================================
    //  SEARCH METHODS (solution)
    // =========================================================

    // 1. Linear search with a for loop.
    //    Return the index of the FIRST match, or -1 if not found.
    //    Do not use Array.IndexOf.
    public static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i;
            }
        }

        return -1;
    }

    // 2. Linear search on book titles with a for loop.
    //    Upper or lower case should not matter:
    //    "holes", "HOLES" and "Holes" all find Holes.
    //    Hint: compare items[i].ToLower() with title.ToLower()
    //    Return the index, or -1 if not found.
    public static int FindBook(string[] items, string title)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ToLower() == title.ToLower())
            {
                return i;
            }
        }

        return -1;
    }

    // 3. Binary search with low, mid and high (the array is sorted).
    //    Return the index, or -1 if not found.
    //    Do not use Array.BinarySearch.
    public static int BinarySearch(int[] sortedArr, int target)
    {
        int low = 0;
        int high = sortedArr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (sortedArr[mid] == target)
            {
                return mid;
            }
            else if (sortedArr[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }

    // 4. Same as BinarySearch, but return HOW MANY times arr[mid]
    //    was checked, whether the target was found or not.
    //    Example: card 2041 takes 2 comparisons,
    //    and card 2010 (not found) takes 4 comparisons.
    public static int CountBinarySearchSteps(int[] sortedArr, int target)
    {
        int low = 0;
        int high = sortedArr.Length - 1;
        int steps = 0;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            steps++;

            if (sortedArr[mid] == target)
            {
                return steps;
            }
            else if (sortedArr[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return steps;
    }

    // 5. Built in method: use Array.FindIndex with a test (p => ...).
    //    Return the index of the first page count LESS THAN maxPages,
    //    or -1 if there is none.
    public static int FindFirstShorterThan(int[] pageCounts, int maxPages)
    {
        return Array.FindIndex(pageCounts, p => p < maxPages);
    }
}
