using Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var grid = new SquareGrid<char>(lines.Select(x => x.ToCharArray()).ToArray());
        var symbolDictionary = CreateSymbolDictionary(grid);
        Console.WriteLine($"Part 1: {SolvePart1(symbolDictionary)}");
        Console.WriteLine($"Part 2: {SolvePart2(symbolDictionary)}");
    }

    private static int SolvePart1(Dictionary<Tile<char>, List<int>> symbolDictionary)
    {
        return symbolDictionary.Values.SelectMany(x => x).Sum();
    }

    private static int SolvePart2(Dictionary<Tile<char>, List<int>> symbolDictionary)
    {
        return symbolDictionary
            .Where(x => x.Key.Contents == '*')
            .Where(x => x.Value.Count == 2)
            .Select(x => x.Value[0] * x.Value[1])
            .Sum();
    }

    private static Dictionary<Tile<char>, List<int>> CreateSymbolDictionary(SquareGrid<char> grid)
    {
        var symbolDictionary = grid.Tiles
            .Where(x => !char.IsDigit(x.Contents) && x.Contents != '.')
            .ToDictionary(symbolTile => symbolTile, _ => new List<int>());

        foreach (var symbolTile in symbolDictionary.Keys)
        {
            var partNumberNeighbours =
                grid.GetNeighbours(symbolTile, includeDiagonal: true)
                    .Where(x => char.IsDigit(x.Contents));

            var checkedTiles = new HashSet<Tile<char>>();
 
            foreach (var partNumberNeighbour in partNumberNeighbours)
            {
                if (checkedTiles.Contains(partNumberNeighbour)) continue;
                var relatives = new List<Tile<char>> { partNumberNeighbour };
                var westernDigitTiles = grid.GetWesternTiles(partNumberNeighbour).TakeWhile(x => char.IsDigit(x.Contents));
                var easternDigitTiles = grid.GetEasternTiles(partNumberNeighbour).TakeWhile(x => char.IsDigit(x.Contents));
                relatives.InsertRange(0, westernDigitTiles.Reverse());
                relatives.AddRange(easternDigitTiles);
                foreach (var relative in relatives)
                {
                    checkedTiles.Add(relative);
                }
                var number = int.Parse(new string(relatives.Select(x => x.Contents).ToArray()));
                symbolDictionary[symbolTile].Add(number);
            }
        }

        return symbolDictionary;
    }
}