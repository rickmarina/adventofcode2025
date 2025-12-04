using System.Security;

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

                int t = RollsAround(map, y, x);
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

    private static int RollsAround(char[][] map, int r, int c) => map.GetNeighbours8(r, c).Where(map.InBounds).Count(x=> map.At(x) =='@');

    public void SolvePart2()
    {
        var map = File.ReadAllLines("./day4/input.txt").Select(x => x.ToCharArray()).ToArray();
        map.Print();
        (int total, int partial) = (0, 0);

        do
        {
            partial = 0;
            var mapPartial = Helpers.CopyMatrix(map);
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[0].Length; x++)
                {
                    if (map.At((y, x)) != '@')
                        continue;

                    int t = RollsAround(map, y, x);
                    if (t < 4)
                    {
                        mapPartial[y][x] = 'x';
                        partial++;
                    }
                }
            }
            total += partial;
            mapPartial.Print();
            map = Helpers.CopyMatrix(mapPartial);

        } while (partial > 0);

        System.Console.WriteLine($"Answer: {total}");
    }
}