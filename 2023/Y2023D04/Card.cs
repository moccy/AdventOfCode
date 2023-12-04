namespace Y2023D04;

public class Card
{
    public int Id { get; }
    public IEnumerable<int> WinningNumbers { get; }
    
    public IEnumerable<int> ActualNumbers { get; }

    public Card(string line)
    {
        var firstSplit = line.Split(": ");
        Id = int.Parse(firstSplit[0].Split(' ').Last());
        var secondSplit = firstSplit[1].Split(" | ");
        WinningNumbers = secondSplit[0].Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse);
        ActualNumbers = secondSplit[1].Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse);
    }
}