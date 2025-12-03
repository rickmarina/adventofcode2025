using System.Security.Cryptography.X509Certificates;

/// <summary>
/// --- Day 3: Lobby ---
/// </summary>
public class Day3 : IDay
{

    //17432
    public void SolvePart1()
    {
        var banks = File.ReadAllLines("./day3/input.txt");
        int n = banks[0].Length;
        int sum = 0;

        foreach (string bank in banks)
        {
            System.Console.Write($"bank: {bank} ");

            int idx = Array.FindIndex(bank.ToCharArray(), x => x == bank.Max());
            if (idx == n - 1)
                idx = Array.FindIndex(bank.ToCharArray(), x => x == bank[..^1].Max());

            //get max joltage 
            string maxjoltage = $"{bank[idx]}{bank[(idx + 1)..].Max()}";
            System.Console.WriteLine($"max joltage: {maxjoltage}");
            sum += int.Parse(maxjoltage);
        }

        System.Console.WriteLine($"sum: {sum}");


    }

    //173065202451341
    public void SolvePart2()
    {

        var banks = File.ReadAllLines("./day3/input.txt");
        int n = banks[0].Length;
        decimal sum = 0;

        foreach (string bank in banks)
        {
            // System.Console.WriteLine($"bank: {bank} ");
            char[] maxjoltage = new char[12];

            int idx1 = 0;
            int idx2 = n - 12 + 1;

            for (int i = 0; i < 12; i++)
            {
                ReadOnlySpan<char> span = bank.AsSpan(idx1, idx2- idx1);

                // Search for max char in span
                char maxChar = span[0];
                int maxIdx = 0;

                for (int j = 1; j < span.Length; j++)
                {
                    if (span[j] > maxChar)
                    {
                        maxChar = span[j];
                        maxIdx = j;
                    }
                }

                maxjoltage[i] = maxChar;
                idx1 += maxIdx + 1;
                idx2++;
            }
            sum += decimal.Parse(new string(maxjoltage));
        }
        System.Console.WriteLine($"sum: {sum}");
    }
}