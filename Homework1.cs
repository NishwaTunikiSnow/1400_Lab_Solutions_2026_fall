CS 1400 – Homework 2: Answer Key
Binary Shift Operations & Order of Operations
Problem 1 Answer
Expression:
13 << 2 >> 1 << 3
Convert 13 to binary:
13 = 1101
First shift: 1101 << 2
110100
Decimal:
52
Next: 110100 >> 1
011010
or simply:
11010
Decimal:
26
Next: 11010 << 3
11010000
Final binary:
11010000
Convert to decimal:
128 + 64 + 16 = 208
Final Answer: 11010000₂ = 208₁₀
Problem 2 Answer
Expression:
25 >> 2 << 3 >> 1
Convert 25 to binary:
25 = 11001
First shift: 11001 >> 2
00110
or:
110
Decimal:
6
Next: 110 << 3
110000
Decimal:
48
Next: 110000 >> 1
011000
or:
11000
Final binary:
11000
Convert to decimal:
16 + 8 = 24
Final Answer: 11000₂ = 24₁₀
Problem 3 Answer
Expression:
18 + 4 * 3 > 25 && 16 / 4 == 4 || 7 < 2
Multiplication and division first:
18 + 12 > 25 && 4 == 4 || 7 < 2
Addition:
30 > 25 && 4 == 4 || 7 < 2
Comparisons:
true && true || false
&& before ||:
true || false
Final result:
true
Answer: true
Problem 4 Answer
Expression:
24 - 5 * 3 <= 10 || 6 + 2 << 1 > 12 && 9 != 9
Multiplication first:
24 - 15 <= 10 || 6 + 2 << 1 > 12 && 9 != 9
Addition/subtraction:
9 <= 10 || 8 << 1 > 12 && 9 != 9
Shift:
9 <= 10 || 16 > 12 && 9 != 9
Comparisons:
true || true && false
&& before ||:
true || false
Final result:
true
Answer: true
give this in c#file
