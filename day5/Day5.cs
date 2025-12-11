namespace adventofcode2025;

/// <summary>
/// --- Day 5: Cafeteria ---
/// </summary>

public class Day5 : IDay
{
    public void SolvePart1()
    {
        var blocks = File.ReadAllText("./day5/input.txt").Split("\r\n\r\n").ToList(); 

        var ranges = blocks[0].Split("\n").Select(x=>
        {
            var parts = x.Split('-');
            return (decimal.Parse(parts[0]), decimal.Parse(parts[1]));
        }); 
        var ingredients = blocks[1].Split("\n").Select(decimal.Parse).ToArray();
        
        decimal totalFresh = 0; 
        
        foreach (var ing in ingredients)
        {
            if (ranges.Any(x=> ing >= x.Item1 && ing <= x.Item2))
            {
                totalFresh++;
            }
        }

        System.Console.WriteLine($"Total fresh ingredients: {totalFresh}");
    }

    //350939902751909
    // ordering ranges by start is usefull for merging in one pass
    // then we can just sum the lengths of the merged ranges
    public void SolvePart2()
    {
        var blocks = File.ReadAllText("./day5/input.txt").Split("\r\n\r\n").ToList(); 

        var ranges = blocks[0].Split("\n").Select(x=>
        {
            var parts = x.Split('-');
            return (decimal.Parse(parts[0]), decimal.Parse(parts[1]));
        }); 

        var mergedRanges = new List<(decimal, decimal)>();
        foreach (var range in ranges.OrderBy(x=> x.Item1))
        {
            if (mergedRanges.Count == 0)
            {
                mergedRanges.Add(range);
            }
            else
            {
                var lastRange = mergedRanges.Last();
                var joined = JoinRanges(lastRange, range);
                if (joined == (0,0))
                {
                    mergedRanges.Add(range);
                }
                else
                {
                    mergedRanges[^1] = joined;
                }
            }
        }

        decimal totalFresh = mergedRanges.Sum(x=> x.Item2 - x.Item1 + 1);

        System.Console.WriteLine($"Total fresh ingredients after merging ranges: {totalFresh}");
    }

    public static (decimal, decimal) JoinRanges((decimal, decimal) range1, (decimal, decimal) range2)
    {
        if (range1.Item2 < range2.Item1 || range2.Item2 < range1.Item1)
            return (0, 0); // No overlap

        return (Math.Min(range1.Item1, range2.Item1), Math.Max(range1.Item2, range2.Item2));
    }


}