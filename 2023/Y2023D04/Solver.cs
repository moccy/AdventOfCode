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
        var cardCounts = new int[_cards.Length];
        Array.Fill(cardCounts, 1); // Initialize all card counts to 1 (for the original cards)

        for (int i = 0; i < _cards.Length; i++)
        {
            int matchCount = _cardMatchCounts[_cards[i].Id];
            for (int j = 1; j <= matchCount && i + j < _cards.Length; j++)
            {
                cardCounts[i + j] += cardCounts[i];
            }
        }

        return cardCounts.Sum();
    }
}