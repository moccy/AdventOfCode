namespace Utils;
public class SquareGrid<T> where T: IEquatable<T>
{
    public readonly Tile<T>[] Tiles;
    private readonly int _rowLength;

    public SquareGrid(IReadOnlyList<T[]> tileContents)
    {
        if (tileContents.Count == 0)
        {
            Tiles = Array.Empty<Tile<T>>();
        }

        _rowLength = tileContents[0].Length;
        Tiles = new Tile<T>[tileContents.Count * _rowLength];

        for (var i = 0; i < tileContents.Count; i++)
        {
            if (tileContents[i].Length != _rowLength)
            {
                throw new ArgumentException("All rows must be equal length in grid.");
            }

            for (var j = 0; j < tileContents[i].Length; j++)
            {
                Tiles[(tileContents.Count * i) + j] = new Tile<T>
                {
                    Contents = tileContents[i][j],
                    Y = i,
                    X = j
                };
            }
        }
    }

    public IEnumerable<Tile<T>> GetNeighbours(Tile<T> tile, bool includeDiagonal = false)
    {
        var directions = new List<(int, int)>
        {
            (1, 0),     // Right
            (0, 1),     // Up
            (-1, 0),    // Left
            (0, -1)     // Down
        };

        if (includeDiagonal)
        {
            directions.AddRange(new[] {
                (1, 1),     // Top Right
                (-1, 1),    // Top Left
                (-1, -1),   // Bottom Left
                (1, -1)     // Bottom Right
            });
        }

        foreach (var (dx, dy) in directions)
        {
            var neighbour = Tiles.FirstOrDefault(t =>
                t.X == tile.X + dx &&
                t.Y == tile.Y + dy
            );

            if (neighbour != default)
            {
                yield return neighbour;
            }
        }
    }

    public IEnumerable<Tile<T>> GetEasternTiles(Tile<T> tile)
    {
        for (var x = tile.X + 1; x < _rowLength; x++)
        {
            yield return Tiles[x + tile.Y * _rowLength];
        }
    }
    
    public IEnumerable<Tile<T>> GetWesternTiles(Tile<T> tile)
    {
        for (var x = tile.X - 1; x >= 0; x--)
        {
            yield return Tiles[x + tile.Y * _rowLength];
        }
    }

    public bool AreVerticalNeighbours(Tile<T> tile1, Tile<T> tile2)
    {
        return tile1.X == tile2.X && Math.Abs(tile1.Y - tile2.Y) == 1;
    }

    public bool AreHorizontalNeighbours(Tile<T> tile1, Tile<T> tile2)
    {
        return tile1.Y == tile2.Y && Math.Abs(tile1.X - tile2.X) == 1;
    }
}

public record struct Tile<T> where T:IEquatable<T>
{
    public int X { get; init; }
    public int Y { get; init; }
    public T Contents { get; init; }
}