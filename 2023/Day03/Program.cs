using Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");

        var grid = new SquareGrid<char>(lines.Select(x => x.ToCharArray()).ToArray());

        var symbolTiles = grid.Tiles
            .Where(x => !char.IsDigit(x.Contents) && x.Contents != '.');

        var partNumbers = new List<int>();

        foreach (var tile in symbolTiles)
        {
            var partNumberNeighbours =
                grid.GetNeighbours(tile, includeDiagonal: true)
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
                partNumbers.Add(number);
            }
        }
        
        Console.WriteLine($"Sum: {partNumbers.Sum()}");
    }
}