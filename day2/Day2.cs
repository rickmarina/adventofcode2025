namespace adventofcode2025;

/// <summary>
/// --- Day 2: Gift Shop ---
/// </summary>
public class Day2 : IDay
{
    //30323879646
    public void SolvePart1()
    {
        var ranges = File.ReadAllText("./day2/input.txt").Split(',').Select(x=> (decimal.Parse(x.Split('-')[0]), decimal.Parse(x.Split('-')[1]))).ToList();

        int total = 0; 
        decimal sum = 0; 

        foreach ((decimal min, decimal max) in ranges)
        {
            System.Console.Write($"{min} - {max} :");
            for (var i = min; i<= max; i++)
            {
                string str = i.ToString();
                int n = str.Length;

                if (n % 2 == 0)
                {
                    if (str[0..(n/2)] == str[(n/2)..n])
                    {
                        total++;
                        sum+= i;
                        System.Console.Write($" {i} ");
                    }
                }
            }

            System.Console.WriteLine();
        }
        System.Console.WriteLine($"Total invalid: {total} sum: {sum} ");
    }

    //43872163557
    public void SolvePart2()
    {
        var ranges = File.ReadAllText("./day2/input.txt").Split(',').Select(x=> (decimal.Parse(x.Split('-')[0]), decimal.Parse(x.Split('-')[1]))).ToList();

        int total = 0; 
        decimal sum = 0; 

        foreach ((decimal min, decimal max) in ranges)
        {
            Console.Write($"{min} - {max} :");
            for (var i = min; i<= max; i++)
            {
                var repeated = RepeatedBlocksStr(i.ToString()); 
                if (repeated > 0)
                {
                    total++;
                    sum+=i;
                    Console.Write($" {i} ");
                }
            }

            Console.WriteLine();
        }
        Console.WriteLine($"Total invalid: {total} sum: {sum} ");
    }

    public static int RepeatedBlocksStr(string str)
    {
        int repeated = 0;
        for (int i=1; i<= str.Length/2; i++)
        {
            string concat = string.Concat(Enumerable.Repeat(str[0..i], str.Length/i));
            if (concat == str) {
                System.Console.WriteLine($"Found repeated block size {concat} =  {str}");
                repeated++;
            }
        }
        return repeated;
    }
}