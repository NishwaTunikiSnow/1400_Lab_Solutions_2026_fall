//First
// Secret Message Shift Coder - solution
// No custom methods, no loops, no if/else/ternary.

Console.Write("Enter a lowercase letter: ");
char originalCharacter = char.Parse(Console.ReadLine());

Console.Write("Enter a shift amount (a whole number): ");
int shiftAmount = int.Parse(Console.ReadLine());

// Where this letter sits in the alphabet, 0 for 'a' through 25 for 'z'.
int offset = (int)originalCharacter - (int)'a';

// The %26 wraps any shift back into a 0-25 range on its own - no if
// statement needed to catch "went past z" or "went before a".
// Adding 26 before the second %26 handles negative shift amounts,
// since C#'s % can return a negative result for a negative left side.
int shiftedOffset = ((offset + shiftAmount) % 26 + 26) % 26;

char shiftedCharacter = (char)('a' + shiftedOffset);

System.Diagnostics.Debug.Assert(
    shiftedCharacter >= 'a' && shiftedCharacter <= 'z',
    "Shifted character should stay a lowercase letter");

Console.WriteLine($"'{originalCharacter}' shifted by {shiftAmount} is '{shiftedCharacter}'");

//Second
// Grade Calculator - solution

using System.Diagnostics;

Console.Write("Points earned: ");
int pointsEarned = int.Parse(Console.ReadLine());

Console.Write("Points possible: ");
int pointsPossible = int.Parse(Console.ReadLine());

double percentage = (double)pointsEarned / pointsPossible * 100;

Debug.Assert(percentage >= 0, "Percentage should never be negative");

int percentageInt = (int)percentage; // truncate to a whole number for bucketing

// Distance below 99 tells us how many 10-point buckets we've dropped from an A.
// (99, not 100, so that exactly 90% still lands in the A bucket.)
int gradeIndex = (99 - percentageInt) / 10;

// Turn the bucket number into a letter grade.
// gradeIndex <= 0 also catches bonus points (percentage over 100), and the
// trailing 'F' with no condition also catches any very low score.
char grade = gradeIndex <= 0 ? 'A'
           : gradeIndex == 1 ? 'B'
           : gradeIndex == 2 ? 'C'
           : gradeIndex == 3 ? 'D'
           : 'F';

Debug.Assert(grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'F',
    "grade should always be one of A, B, C, D, or F");

Console.WriteLine($"You earned {percentage:F1}% -- that's a {grade}.");
