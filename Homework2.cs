HW2 Solution Key: Structure, Methods & Operators
Reference solutions for all 6 required problems plus the bonus. Sample output is shown for the values used here — students' own names, chosen values for x/y, etc. will produce different (but equally correct) output.
Problem 1: Program Structure & Comments
// Name: Jane Student
// Date: 08/25/2026
// HW1: Structure, Methods & Operators

// Prints my name to the console
Console.WriteLine("Jane Student");

// Prints my major to the console
Console.WriteLine("Computer Science");

// Prints a fun fact about myself to the console
Console.WriteLine("I have visited 12 different countries.");
Sample output:
Jane Student
Computer Science
I have visited 12 different countries.
Problem 2: Calling Methods & Output
// Prints a short "About Me" message
Console.WriteLine("Hi, I'm Jane.");
Console.WriteLine("I'm a first-year Computer Science major.");
Console.WriteLine("This is my first semester writing C#.");
Console.WriteLine("I'm excited to learn how to build programs!");

// Ask for the user's name
Console.Write("What is your name? ");
// Console.ReadLine() always returns a string, even if the user types a number
string userName = Console.ReadLine();

// Ask for the user's favorite number
Console.Write("What is your favorite number? ");
string favoriteInput = Console.ReadLine();
// Convert the text the user typed into an actual int so we could do math with it if needed
int favoriteNumber = int.Parse(favoriteInput);

Console.WriteLine($"Hi {userName}, your favorite number is {favoriteNumber}!");
Sample output (user typed "Alex" then "7"):
Hi, I'm Jane.
I'm a first-year Computer Science major.
This is my first semester writing C#.
I'm excited to learn how to build programs!
What is your name? Alex
What is your favorite number? 7
Hi Alex, your favorite number is 7!
Note: Console.ReadLine() always returns a string. If you want to use the input as a number (to add, compare, etc.), you must convert it first with int.Parse() or double.Parse() — otherwise C# treats it as text.
Problem 3: Arithmetic Operators: Int vs. Double Division
int a = 17;
int b = 5;
Console.WriteLine($"a + b = {a + b}");
Console.WriteLine($"a - b = {a - b}");
Console.WriteLine($"a * b = {a * b}");
Console.WriteLine($"a / b = {a / b}");
Console.WriteLine($"a % b = {a % b}");

double da = 17.0;
double db = 5.0;
Console.WriteLine($"da / db = {da / db}");

// int / int always throws away the remainder ("integer division"),
// because both operands are whole numbers, C# assumes you want a whole-number result.
// double / double keeps the decimal portion because at least one operand is a
// floating-point type, so C# performs real (floating-point) division instead.
Sample output:
a + b = 22
a - b = 12
a * b = 85
a / b = 3
a % b = 2
da / db = 3.4
Problem 4: Boolean, Relational & Logical Operators
int x = 8;
int y = 3;

Console.WriteLine($"x > y: {x > y}");
Console.WriteLine($"x < y: {x < y}");
Console.WriteLine($"x == y: {x == y}");
Console.WriteLine($"x != y: {x != y}");

// Combine two comparisons with AND: both sides must be true
Console.WriteLine($"(x > y) && (y > 0): {(x > y) && (y > 0)}");
// Combine two comparisons with OR: at least one side must be true
Console.WriteLine($"(x == y) || (x != y): {(x == y) || (x != y)}");

// == checks whether two values are equal and gives back true or false.
// = assigns a value to a variable and does not compare anything.
// Writing "if (x = 5)" by accident (using = instead of ==) is a classic beginner bug.
Sample output:
x > y: True
x < y: False
x == y: False
x != y: True
(x > y) && (y > 0): True
(x == y) || (x != y): True
Problem 5: Increment/Decrement & Compound Assignment
int score = 100;
Console.WriteLine($"Starting score: {score}");

// Postfix: prints the CURRENT value, THEN increments
Console.WriteLine($"score++ prints: {score++}");
Console.WriteLine($"Value right after score++: {score}");

// Prefix: increments FIRST, THEN prints the new value
Console.WriteLine($"++score prints: {++score}");
Console.WriteLine($"Value right after ++score: {score}");

score += 10;
Console.WriteLine($"After score += 10: {score}");
score -= 5;
Console.WriteLine($"After score -= 5: {score}");
score *= 2;
Console.WriteLine($"After score *= 2: {score}");
Sample output:
Starting score: 100
score++ prints: 100
Value right after score++: 101
++score prints: 102
Value right after ++score: 102
After score += 10: 112
After score -= 5: 107
After score *= 2: 214
Problem 6: Operator Precedence Challenge
// Prediction: Multiplication and the parentheses happen before + and -.
// Step 1: 3 * 4 = 12
// Step 2: 6 / 2 = 3 (parentheses)
// Step 3: 2 + 12 - 3 = 11
int result = 2 + 3 * 4 - (6 / 2);
Console.WriteLine($"result = {result}");
Sample output:
result = 11
Note: A common wrong first guess is to compute left-to-right (2 + 3 = 5, 5 * 4 = 20, 20 - 6 = 14, 14 / 2 = 7), forgetting that * and / are evaluated before + and - regardless of the order they're written in.
Problem 7: Bonus: Shift Operators
int num = 5;
Console.WriteLine($"5 << 1 = {num << 1}");
Console.WriteLine($"5 >> 1 = {num >> 1}");

// << shifts bits left, which doubles the number for each shift: 5 becomes 10.
// >> shifts bits right, which halves the number (rounding down) for each shift:
// 5 (binary 101) becomes 2 (binary 10) because the last bit is dropped.
Sample output:
5 << 1 = 10
5 >> 1 = 2
