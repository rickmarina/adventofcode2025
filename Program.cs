using System.Diagnostics;
using adventofcode2025;

Console.WriteLine("Advent of code 2025!");

Stopwatch sw = new(); 

sw.Start(); 
IDay day = new Day5();
day.SolvePart2();

sw.Stop();
System.Console.WriteLine($"Time elapsed: {sw.ElapsedMilliseconds} ms");


