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

            int idx = Array.FindIndex(bank.ToCharArray(), x=> x == bank.Max()); 
            if (idx == n-1) 
                idx = Array.FindIndex(bank.ToCharArray(), x=> x == bank[..^1].Max()); 

            //get max joltage 
            string maxjoltage = $"{bank[idx]}{bank[(idx+1)..].Max()}";
            System.Console.WriteLine($"max joltage: {maxjoltage}");
            sum += int.Parse(maxjoltage);
        }

        System.Console.WriteLine($"sum: {sum}");

        
    }

    public void SolvePart2()
    {
        
        var banks = File.ReadAllLines("./day3/input.txt");
        int n = banks[0].Length;
        decimal sum = 0; 

        foreach (string bank in banks)
        {
            System.Console.WriteLine($"bank: {bank} ");
            string maxjoltage = "";

            int idx1 = 0; 
            int idx2 = n-12+1; 

            for (int i=0; i< 12; i++)
            {
                var serie = bank[idx1..idx2];
                var maxSerie = serie.Max();
                var maxIdx = Array.FindIndex(serie.ToCharArray(), x=> x == maxSerie);
                idx1 = idx1 + maxIdx + 1;
                idx2++;
                maxjoltage = $"{maxjoltage}{maxSerie}";
            }

            System.Console.WriteLine($"max joltage: {maxjoltage}");
            sum += decimal.Parse(maxjoltage);
        }
        System.Console.WriteLine($"sum: {sum}");
    }
}