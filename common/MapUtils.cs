public static class MapUtils { 

    public static char At(this char[][] map, (int r, int c) loc) => map[loc.r][loc.c];
    public static char TryAt(this char[][] map, (int r, int c) loc) => map.InBounds(loc) ? map[loc.r][loc.c] : char.MinValue;
    public static bool InBounds(this char[][] map, int r, int c) => (r >= 0 && r < map.Length && c >= 0 && c < map[0].Length);
    public static bool InBounds(this char[][] map, (int r, int c) loc) => (loc.r >= 0 && loc.r < map.Length && loc.c >= 0 && loc.c < map[0].Length);
    public static IEnumerable<(int, int)> GetNeighbours4(this char[][] map, int r, int c) { 
        return new[] {(-1,0), (0,1), (1,0), (0,-1)}.Select(d=> (r+d.Item1, c+d.Item2));
    }
    public static IEnumerable<(int, int)> GetNeighbours8(this char[][] map, int r, int c) { 
        return new[] {(-1,-1), (-1,0), (-1,1), (0,1), (1,1), (1,0), (1,-1), (0,-1)}.Select(d=> (r+d.Item1, c+d.Item2));
    }

    public static void Print(this char[][] map, string separator = "") {
        for (int i=0; i< map.Length;i++) {
            Console.WriteLine(string.Join(separator, map[i]));
        }
    }

    public static char TopLeft(this char[][] map, int r, int c) { 
        int nr = r-1;
        int nc = c-1;
        
        if (map.InBounds(nr,nc)) 
            return map[nr][nc];

        return char.MinValue;
    }

    public static char TopRight(this char[][] map, int r , int c) { 
        int nr = r-1;
        int nc = c+1;
        
        if (map.InBounds(nr,nc)) 
            return map[nr][nc];

        return char.MinValue;
    }

    public static char DownLeft(this char[][] map, int r , int c) { 
        int nr = r+1;
        int nc = c-1;
        
        if (map.InBounds(nr,nc)) 
            return map[nr][nc];

        return char.MinValue;
    }
    public static char DownRight(this char[][] map, int r , int c) { 
        int nr = r+1;
        int nc = c+1;
        
        if (map.InBounds(nr,nc)) 
            return map[nr][nc];

        return char.MinValue;
    }

}