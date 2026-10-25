// Homework 4 Solution: Call Stack and Test Driven Development
// This file holds the written answers as comments next to the actual runnable
// code for the questions that ask for code (Question 2's trace, Question 3's
// fixed CountDown, and Question 7/8's IsPalindrome tests and implementation).

using System;
using System.Linq;
using Xunit;

class Program
{
    // ----------------------------------------------------------------------
    // PART 1: THE CALL STACK
    // ----------------------------------------------------------------------

    // Question 1
    // A stack frame is the block of memory the call stack sets aside for one
    // single method call while that method is running. It typically holds
    // that call's parameters, its local variables, and the return address,
    // meaning where execution should resume once the method finishes.

    // Question 2
    static int Triple(int x)
    {
        int result = x * 3;
        return result;
    }

    static int SumOfTriples(int a, int b)
    {
        int first = Triple(a);
        int second = Triple(b);
        return first + second;
    }

    // Answers for Question 2:
    // - Calls pushed onto the stack, in order: Main, then SumOfTriples, then
    //   Triple (for the call with a), then Triple is popped, then Triple is
    //   pushed again (for the call with b), then popped, then SumOfTriples
    //   is popped.
    // - At the moment the first call to Triple is executing, the stack
    //   holds, from bottom to top: Main, SumOfTriples, Triple.
    // - The moment that call to Triple returns, its entire stack frame is
    //   popped off the stack, and the local variable result inside it is
    //   destroyed along with it.
    // - Yes, SumOfTriples could safely reuse the name "result" as its own
    //   local variable. Each method call gets its own separate stack frame,
    //   so a "result" inside SumOfTriples would live in a completely
    //   different frame from the "result" inside Triple. They never
    //   conflict because they are not the same piece of memory.

    // Question 3
    // Original, broken version (infinite recursion, no base case):
    //
    // static int CountDown(int n)
    // {
    //     Console.WriteLine(n);
    //     return CountDown(n - 1);
    // }
    //
    // CountDown(5) calls itself over and over with no condition that ever
    // stops it, so a new stack frame is pushed for every call and none of
    // them ever get popped, since none of them return. Eventually the call
    // stack runs out of room to hold any more frames, which is a stack
    // overflow, and the program crashes with a StackOverflowException.
    //
    // Fixed version, with a base case added so the recursion actually stops:
    static int CountDown(int n)
    {
        if (n <= 0)
        {
            Console.WriteLine(0);
            return 0;
        }

        Console.WriteLine(n);
        return CountDown(n - 1);
    }

    // Question 4
    // The statement "local variables live in the heap so they stick around
    // after the method returns" is incorrect. A method's ordinary local
    // variables live on the call stack, inside that method's own stack
    // frame, not on the heap. When the method returns, its stack frame (and
    // everything in it, including its local variables) is destroyed
    // immediately, so those values are not kept around for later use. Data
    // that does need to persist after a method returns is either returned
    // to the caller, stored somewhere outside the method (such as a field
    // on an object), or is itself a reference type whose underlying data
    // lives on the heap while only a reference to it sits on the stack.

    // ----------------------------------------------------------------------
    // PART 2: TEST DRIVEN DEVELOPMENT
    // ----------------------------------------------------------------------

    // Question 5
    // Red: write a test for behavior that does not exist yet, so the test
    // fails (or does not even compile).
    // Green: write the simplest possible code that makes that test pass,
    // without worrying yet about how clean the code is.
    // Refactor: improve the code's structure and readability while keeping
    // every test passing, without changing what the code actually does.

    // Question 6
    // The test is written first because TDD uses the test to define what
    // the method is supposed to do before any code exists to do it. That
    // first run is expected to fail because the method it is testing has no
    // real implementation yet, so there is nothing that could make the test
    // pass. If that first test passed right away, it would be a warning
    // sign, either the test is not actually checking anything meaningful,
    // or the behavior already exists somewhere else, and either way it is
    // worth stopping to figure out why before trusting the test going
    // forward.

    // Question 7 and 8: IsPalindrome
    // Simplest implementation that makes all of the tests below pass.
    // Marked public static so the xUnit tests below can call it directly.
    public static bool IsPalindrome(string text)
    {
        string lowered = text.ToLower();
        string reversed = new string(lowered.Reverse().ToArray());
        return lowered == reversed;
    }

    // Question 8 answer: once every test is green, the Refactor step allows
    // changes to the internal structure of the code, such as renaming
    // variables, simplifying an expression, or removing duplication, as
    // long as the method's observable behavior does not change. What must
    // stay true the whole time is that every existing test keeps passing
    // after each small change; if a refactor ever breaks a test, that
    // change is undone or fixed before moving on.

    // Question 9
    // One concrete advantage is that TDD leaves you with a full, automated
    // set of regression tests once the method is done, so if you (or
    // someone else) change the code later and accidentally break something,
    // the tests catch it immediately instead of the bug slipping through
    // unnoticed. Testing manually by running the program a few times only
    // checks the specific cases you happened to try in that moment, and
    // none of that checking is saved or repeated automatically the next
    // time the code changes.

    static void Main()
    {
        // Quick manual demonstration of the fixed CountDown from Question 3
        CountDown(5);

        // Quick manual demonstration of IsPalindrome from Question 7/8
        Console.WriteLine(IsPalindrome("racecar")); // True
        Console.WriteLine(IsPalindrome("hello"));   // False
    }
}

// xUnit tests for Question 7, written before any implementation existed.
public class IsPalindromeTests
{
    [Fact]
    public void IsPalindrome_Racecar_ReturnsTrue()
    {
        Assert.True(Program.IsPalindrome("racecar"));
    }

    [Fact]
    public void IsPalindrome_NotAPalindrome_ReturnsFalse()
    {
        Assert.False(Program.IsPalindrome("hello"));
    }

    [Fact]
    public void IsPalindrome_EmptyString_ReturnsTrue()
    {
        Assert.True(Program.IsPalindrome(""));
    }

    [Fact]
    public void IsPalindrome_SingleCharacter_ReturnsTrue()
    {
        Assert.True(Program.IsPalindrome("a"));
    }

    [Fact]
    public void IsPalindrome_MixedCase_ReturnsTrue()
    {
        Assert.True(Program.IsPalindrome("RaceCar"));
    }
}
