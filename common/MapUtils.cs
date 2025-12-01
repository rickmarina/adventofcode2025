public static class MapUtils { 

    public static char At(this char[][] map, Location<int> loc) => map[loc.y][loc.x];
    public static char TryAt(this char[][] map, Location<int> loc) => map.InBounds(loc.y, loc.x) ? map[loc.y][loc.x] : char.MinValue;
    public static bool InBounds(this char[][] map, int r, int c) => (r >= 0 && r < map.Length && c >= 0 && c < map[0].Length);
    public static bool InBounds(this char[][] map, (int r, int c) loc) => (loc.r >= 0 && loc.r < map.Length && loc.c >= 0 && loc.c < map[0].Length);
    public static IEnumerable<(int, int)> GetNeighbours4(this char[][] map, int r, int c) { 
        return new[] {(-1,0), (0,1), (1,0), (0,-1)}.Select(d=> (r+d.Item1, c+d.Item2));
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