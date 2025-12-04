namespace adventofcode2025;

/// <summary>
/// --- Day 4: Printing Department ---
/// </summary>
public class Day4 : IDay
{
    //1516
    public void SolvePart1()
    {
        var map = File.ReadAllLines("./day4/input.txt").Select(x => x.ToCharArray()).ToArray();

        var mapFinal = Helpers.CopyMatrix(map);

        map.Print();

        int ans = 0;

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                if (map.At((y, x)) != '@')
                    continue;

                int t = CountRollsAround(map, y, x);
                if (t < 4)
                {
                    mapFinal[y][x] = 'x';
                    ans++;
                }
            }
        }

        mapFinal.Print();

        System.Console.WriteLine($"Answer: {ans}");

    }

    private int CountRollsAround(char[][] map, int r, int c)
    {
        int count = 0;
        foreach (var point in map.GetNeighbours8(r, c))
        {
            if (map.InBounds(point) && map.At(point) == '@')
                count++;
        }
        return count;
    }

    public void SolvePart2()
    {
        var map = File.ReadAllLines("./day4/input.txt").Select(x => x.ToCharArray()).ToArray();
        map.Print();
        int ans = 0;
        int partialAns;

        do
        {
            partialAns = 0;

            var mapFinal = Helpers.CopyMatrix(map);

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[0].Length; x++)
                {
                    if (map.At((y, x)) != '@')
                        continue;

                    int t = CountRollsAround(map, y, x);
                    if (t < 4)
                    {
                        mapFinal[y][x] = 'x';
                        partialAns++;
                    }
                }
            }
            ans += partialAns;
            mapFinal.Print();
            map = Helpers.CopyMatrix(mapFinal);

        } while (partialAns > 0);

        System.Console.WriteLine($"Answer: {ans}");
    }
}