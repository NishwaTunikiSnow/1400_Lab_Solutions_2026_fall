// Name: [Your Name]
// Lab: Lab 03 - C# Methods and Conditional Statements
// Date: [Submission Date]

// Step 2: Test the TicketPrice method with several combinations
Console.WriteLine(TicketPrice(30, false, "evening")); // regular adult, evening -> 12
Console.WriteLine(TicketPrice(5, false, "evening"));  // free child -> 0
Console.WriteLine(TicketPrice(6, false, "evening"));  // discounted child, no matinee -> 8
Console.WriteLine(TicketPrice(70, true, "matinee"));  // senior, member, matinee -> stacked discounts
Console.WriteLine(TicketPrice(30, true, "matinee"));  // adult, member, matinee
Console.WriteLine(TicketPrice(13, false, "matinee")); // regular price, matinee only

Console.WriteLine();

// Step 3: Read input from the user and print a result
Console.WriteLine("Let's calculate your movie ticket price.");

Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

Console.Write("Are you a theater member? (y/n): ");
bool isMember = Console.ReadLine().Trim().ToLower() == "y";

Console.Write("Enter the show time (matinee/evening): ");
string showTime = Console.ReadLine().Trim().ToLower();

double price = TicketPrice(age, isMember, showTime);
Console.WriteLine($"Your ticket price is: ${price:F2}");

Console.WriteLine();

// Step 4: Experiment with edge cases
Console.WriteLine("Edge case experiments:");
Console.WriteLine(TicketPrice(5, false, "evening"));        // exactly 5, free
Console.WriteLine(TicketPrice(6, false, "matinee"));        // exactly 6, discounted + matinee
Console.WriteLine(TicketPrice(70, true, "matinee"));        // senior + member + matinee, all stacked
Console.WriteLine(TicketPrice(30, true, "midnight"));       // unrecognized show time, no matinee discount applied

// Step 1: The TicketPrice method
double TicketPrice(int age, bool isMember, string showTime)
{
    // Children age 5 and under always get in free, no other rules apply
    if (age <= 5)
    {
        return 0.00;
    }

    // Determine the base price based on age
    double price;
    if (age >= 65 || (age >= 6 && age <= 12))
    {
        price = 8.00;
    }
    else
    {
        price = 12.00;
    }

    // Members get an additional 20% off the base price that already applies to them
    if (isMember)
    {
        price = price * 0.80;
    }

    // Matinee showings get a flat $3.00 off, applied after the member discount
    if (showTime == "matinee")
    {
        price = price - 3.00;
    }

    // The price can never go below $0.00
    if (price < 0.00)
    {
        price = 0.00;
    }

    return price;
}
