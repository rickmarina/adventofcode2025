namespace adventofcode2025.day1;

/// <summary>
/// --- Day 1: Secret Entrance ---
/// </summary>
public class Day1 : IDay
{
    public void SolvePart1()
    {
        var lines = File.ReadAllLines("./day1/input.txt");
        int n = 100;
        int idx = 50;
        int total = 0;

        foreach (var i in lines)
        {
            if (i.StartsWith("L"))
            {
                idx = (idx + (-1 * int.Parse(i[1..]) % n) + n) % n;
            }
            else if (i.StartsWith("R"))
            {
                idx = (idx + (int.Parse(i[1..]) % n) + n) % n;
            }

            if (idx == 0)
                total++;

            // System.Console.WriteLine($"{i} new dial index: {idx}");
            // Console.ReadKey();
        }

        System.Console.WriteLine($"Total Zeros: {total}");

    }

// 6932
    public void SolvePart2()
    {
        var instructions = File.ReadAllLines("./day1/input.txt").Select(x=> x.StartsWith('L') ? x.Replace("L","-") : x.Replace("R","")).Select(int.Parse).ToList();
        int n = 100;
        int dial = 50;
        int total = 0;

        foreach (var ins in instructions)
        {

            if (ins < 0)
            {
                (int div, int mod) = DivMod(ins, -100);
                total += div; 
                if (dial != 0 && dial+mod < 0) {
                    System.Console.Write($"pass zero ");
                    total++;
                }
            } else
            {
                (int div, int mod) = DivMod(ins, 100);
                total += div; 
                if (dial + mod > n)
                {
                    System.Console.Write($"pass zero ");
                    total++;
                }
            }

            dial = (((dial + ins) % 100)+n ) % n; 
            if (dial == 0)
                total++;


            System.Console.WriteLine($"{ins} dial at: {dial}");
        }

        System.Console.WriteLine($"Total Zeros: {total}");
    }

    private static (int, int) DivMod(int a, int b) => (a / b, a % b);
}