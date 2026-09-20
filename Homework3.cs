using System;

/*
 * ============================================================
 *  SNOW COLLEGE  |  Introduction to Programming
 *  Mastering Loops in C#  |  INSTRUCTOR SOLUTION KEY
 * ============================================================
 *
 * This file is a full answer key for the "Mastering Loops in C#"
 * assignment (for, while, and do while). Each problem is its own
 * method, called in order from Main() with a header printed
 * before it runs. Interactive problems (the ones that call
 * Console.ReadLine) will pause and wait for input when you run
 * the whole file top to bottom, exactly like a student's program
 * would.
 *
 * ============================================================
 *  PART 1: CONCEPT CHECK  (sample answers, 10 points)
 * ============================================================
 * These are short answer questions, so grade for understanding
 * in the student's own words, not an exact match to this text.
 *
 * 1. Keywords:
 *      for loop: for
 *      while loop: while
 *      do while loop: do, while
 *
 * 2. A while loop checks its condition BEFORE the body runs, so
 *    it can run zero times. A do while loop checks its condition
 *    AFTER the body runs, so the body always runs at least once,
 *    even if the condition would have been false from the start.
 *
 * 3. The three parts of a for loop header:
 *      Initialization (e.g. int i = 0): runs once, before the loop starts
 *      Condition      (e.g. i < 5): checked before every pass
 *      Update/Increment (e.g. i++): runs at the end of every pass
 *
 * 4. A nested loop is a loop placed inside the body of another
 *    loop. You use one when a single counter is not enough to
 *    describe the pattern, for example printing a pyramid where
 *    the outer loop picks the row and the inner loop prints that
 *    row's characters one at a time.
 *
 * 5. Do while loop. The menu must display at least once before
 *    the user can even choose "Quit," so the loop's body has to
 *    run before its exit condition can be checked.
 *
 * 6. An infinite loop is a loop whose condition never becomes
 *    false, so it never stops on its own. It is usually caused by
 *    a missing or wrong update step (forgetting i++ in a while
 *    loop, for example), or an update that moves the variable in
 *    the wrong direction.
 *
 * 7. Sample real world examples (answers will vary):
 *      for loop: printing a receipt with a fixed number of line items
 *      while loop: a video game that keeps running while the player's health is above 0
 *      do while loop: an ATM that always shows its main menu once, then repeats until "Exit" is chosen
 * ============================================================
 */

class Program
{
    static void Main()
    {
        RunSection("PART 2, PROBLEM 1: Inverted Star Pyramid", Part2_Problem1_InvertedStarPyramid);
        RunSection("PART 2, PROBLEM 2: Right Triangle of Numbers", Part2_Problem2_RightTriangleOfNumbers);
        RunSection("PART 2, PROBLEM 3: Multiplication Table", Part2_Problem3_MultiplicationTable);
        RunSection("PART 2, PROBLEM 4: Sum of Even Numbers", Part2_Problem4_SumOfEvenNumbers);

        RunSection("PART 3, PROBLEM 1: Countdown Launch", Part3_Problem1_CountdownLaunch);
        RunSection("PART 3, PROBLEM 2: Digit Sum", Part3_Problem2_DigitSum);
        RunSection("PART 3, PROBLEM 3: Guess the Number", Part3_Problem3_GuessTheNumber);

        RunSection("PART 4, PROBLEM 1: Simple Menu", Part4_Problem1_SimpleMenu);
        RunSection("PART 4, PROBLEM 2: Positive Number Only", Part4_Problem2_PositiveNumberOnly);
        RunSection("PART 4, PROBLEM 3: Rewrite and Compare", Part4_Problem3_RewriteAndCompare);

        RunSection("PART 5, PROBLEM 1: Fix the Bug (While Loop)", Part5_Problem1_FixTheBugWhile);
        RunSection("PART 5, PROBLEM 2: Fix the Bug (Do While Loop)", Part5_Problem2_FixTheBugDoWhile);
        RunSection("PART 5, PROBLEM 3: Pick the Right Loop", Part5_Problem3_PickTheRightLoop);
        RunSection("PART 5, PROBLEM 4: Diamond of Stars", Part5_Problem4_DiamondOfStars);
        RunSection("PART 5, PROBLEM 5: Number Pyramid", Part5_Problem5_NumberPyramid);

        RunSection("BONUS: FizzBuzz with a Twist", Bonus_FizzBuzzSnow);
    }

    static void RunSection(string title, Action solution)
    {
        Console.WriteLine();
        Console.WriteLine("==================================================");
        Console.WriteLine(title);
        Console.WriteLine("==================================================");
        solution();
    }

    // ================= PART 2: FOR LOOPS =================

    static void Part2_Problem1_InvertedStarPyramid()
    {
        // For loop: the number of rows is known up front, so we count
        // straight down from it.
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        for (int i = rows; i >= 1; i--)
        {
            Console.WriteLine(new string('*', i));
        }
    }

    static void Part2_Problem2_RightTriangleOfNumbers()
    {
        // For loop: the number of rows (4) is fixed and known ahead of time.
        int rows = 4;

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(row);
                if (col < row) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Part2_Problem3_MultiplicationTable()
    {
        // For loop: always exactly 10 lines to print, 1 through 10.
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} x {i} = {n * i}");
        }
    }

    static void Part2_Problem4_SumOfEvenNumbers()
    {
        // For loop: the range (2 to 100) and the step (2) are both known
        // ahead of time.
        int sum = 0;

        for (int i = 2; i <= 100; i += 2)
        {
            sum += i;
        }

        Console.WriteLine($"Sum of even numbers from 2 to 100: {sum}");
        // Expected result: 2550
    }

    // ================= PART 3: WHILE LOOPS =================

    static void Part3_Problem1_CountdownLaunch()
    {
        // While loop: works fine here, but notice the update step (n--)
        // has to be written by hand inside the body.
        Console.Write("Enter a starting number: ");
        int n = int.Parse(Console.ReadLine());

        while (n >= 0)
        {
            Console.WriteLine(n);
            n--;
        }
        Console.WriteLine("Liftoff!");
    }

    static void Part3_Problem2_DigitSum()
    {
        // While loop: we do not know how many digits the number has ahead
        // of time, so we keep going until nothing is left.
        Console.Write("Enter a positive whole number: ");
        int number = int.Parse(Console.ReadLine());
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10; // grabs the last digit
            number /= 10;       // removes the last digit
        }

        Console.WriteLine($"Digit sum: {sum}");
    }

    static void Part3_Problem3_GuessTheNumber()
    {
        // While loop (no do while allowed): we read one guess before the
        // loop starts so the condition has something to check on the very
        // first pass, then read another guess at the end of each loop.
        int secret = 13; // hard coded secret number between 1 and 20

        Console.Write("Guess a number between 1 and 20: ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != secret)
        {
            if (guess > secret)
                Console.WriteLine("Too high");
            else
                Console.WriteLine("Too low");

            Console.Write("Guess again: ");
            guess = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You got it!");
    }

    // ================= PART 4: DO WHILE LOOPS =================

    static void Part4_Problem1_SimpleMenu()
    {
        // Do while loop: the menu has to be shown at least once before the
        // user can ever choose to quit.
        string choice;

        do
        {
            Console.WriteLine("1) Say Hello");
            Console.WriteLine("2) Show Today's Date");
            Console.WriteLine("3) Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
                Console.WriteLine("Hello!");
            else if (choice == "2")
                Console.WriteLine(DateTime.Now.ToShortDateString());
            else if (choice != "3")
                Console.WriteLine("Not a valid option.");

        } while (choice != "3");
    }

    static void Part4_Problem2_PositiveNumberOnly()
    {
        // Do while loop: we cannot check whether the number is positive
        // until after we have asked for it at least once.
        int number;

        do
        {
            Console.Write("Enter a positive number: ");
            number = int.Parse(Console.ReadLine());

            if (number <= 0)
                Console.WriteLine("Please enter a positive number");

        } while (number <= 0);

        Console.WriteLine($"You entered: {number}");
    }

    static void Part4_Problem3_RewriteAndCompare()
    {
        // Same countdown as Part 3, Problem 1, written as a do while loop.
        Console.Write("Enter a starting number: ");
        int n = int.Parse(Console.ReadLine());

        do
        {
            Console.WriteLine(n);
            n--;
        } while (n >= 0);

        Console.WriteLine("Liftoff!");

        // Comparison (sample answer): it does not matter here whether we
        // use while or do while, because the user is always asked for a
        // starting number first, so the body was always going to run at
        // least once anyway.
    }

    // ================= PART 5: MIXED CHALLENGE =================

    static void Part5_Problem1_FixTheBugWhile()
    {
        // Original bug:
        //   int i = 1;
        //   while (i < 5) {
        //       Console.WriteLine(i);
        //   }
        // i was never updated, so the condition (i < 5) was always true
        // and the loop printed 1 forever. Fix: add i++ inside the body.
        int i = 1;
        while (i <= 5)
        {
            Console.WriteLine(i);
            i++;
        }
    }

    static void Part5_Problem2_FixTheBugDoWhile()
    {
        // Original bug:
        //   int i = 5;
        //   do {
        //       Console.WriteLine(i);
        //   } while (i > 0);
        // i was never updated, so the condition (i > 0) stayed true
        // forever and the loop never stopped. Fix: add i-- inside the body.
        int i = 5;
        do
        {
            Console.WriteLine(i);
            i--;
        } while (i > 0);
    }

    static void Part5_Problem3_PickTheRightLoop()
    {
        Console.WriteLine("a) Counting from 1 to 100: FOR loop.");
        Console.WriteLine("   The number of repeats (100) is known ahead of time.");
        Console.WriteLine();
        Console.WriteLine("b) Password prompt, must ask at least once: DO WHILE loop.");
        Console.WriteLine("   The body must run once before its condition can be checked.");
        Console.WriteLine();
        Console.WriteLine("c) Processing exactly 12 months, one at a time: FOR loop.");
        Console.WriteLine("   Again, the number of repeats (12) is fixed and known.");
        Console.WriteLine();
        Console.WriteLine("d) Rolling a die until it lands on 6: WHILE loop.");
        Console.WriteLine("   The number of rolls is unknown ahead of time, and the");
        Console.WriteLine("   condition can reasonably be checked before the first roll.");
    }

    static void Part5_Problem4_DiamondOfStars()
    {
        // Two loops, of any type: here we use two for loops, one for the
        // growing top half (including the widest middle row) and one for
        // the shrinking bottom half.
        int size = 3; // the widest row has 2 * size - 1 stars

        for (int i = 1; i <= size; i++)
        {
            Console.WriteLine(new string(' ', size - i) + new string('*', 2 * i - 1));
        }

        for (int i = size - 1; i >= 1; i--)
        {
            Console.WriteLine(new string(' ', size - i) + new string('*', 2 * i - 1));
        }
    }

    static void Part5_Problem5_NumberPyramid()
    {
        // Nested for loops: the outer loop picks the row, the inner loop
        // counts up from 1 to that row number.
        int rows = 5;

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col);
                if (col < row) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    // ================= BONUS =================

    static void Bonus_FizzBuzzSnow()
    {
        for (int i = 1; i <= 50; i++)
        {
            string output = "";
            if (i % 3 == 0) output += "Fizz";
            if (i % 5 == 0) output += "Buzz";
            if (i % 7 == 0) output += "Snow!";

            Console.WriteLine(output == "" ? i.ToString() : output);
        }
    }
}
