namespace Y2023D04;

public class Solver
{
    private Card[] _cards;
    private Dictionary<int, int> _cardMatchCounts;
    
    public Solver(string[] lines)
    { 
        _cards = lines.Select(line => new Card(line)).ToArray();
        _cardMatchCounts = _cards.ToDictionary(x => x.Id, x => x.ActualNumbers.Intersect(x.WinningNumbers).Count());
    }
    
    public int SolvePart1()
    {
        var dict = new Dictionary<Card, IEnumerable<int>>();
        foreach (var card in _cards)
        {
            var matches = card.ActualNumbers.Intersect(card.WinningNumbers).ToList();
            if (matches.Any())
            {
                dict.Add(card, matches);
            }
        }

        return (int) dict.Values.Sum(x => Math.Pow(2, x.Count() - 1));
    }
    
    public int SolvePart2()
    {
        var cardCounts = _cards.ToDictionary(x => x.Id, _ => 0);
        FindAndAddNextCards(_cards, cardCounts, _cards, _cardMatchCounts);
        return cardCounts.Values.Sum();
    }

    private void FindAndAddNextCards(IEnumerable<Card> cards, IDictionary<int, int> cardCounts, Card[] allCards, IReadOnlyDictionary<int, int> cardMatches)
    {
        foreach (var card in cards)
        {
            var matchCount = cardMatches[card.Id];
            cardCounts[card.Id]++;
            var nextCards = allCards.Where(x => x.Id > card.Id && x.Id <= card.Id + matchCount);
            FindAndAddNextCards(nextCards.ToList(), cardCounts, allCards, cardMatches);
        }
    }
}

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