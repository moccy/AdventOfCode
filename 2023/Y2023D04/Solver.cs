namespace Y2023D04;

public class Solver
{ 
    public static int SolvePart1(string[] lines)
    {
        var cards = lines.Select(line => new Card(line)).ToArray();

        var dict = new Dictionary<Card, IEnumerable<int>>();
        foreach (var card in cards)
        {
            var matches = card.ActualNumbers.Intersect(card.WinningNumbers).ToList();
            if (matches.Any())
            {
                dict.Add(card, matches);
            }
        }

        return (int) dict.Values.Sum(x => Math.Pow(2, x.Count() - 1));
    }
    
    public static int SolvePart2(string[] lines)
    {
        var cards = lines.Select(line => new Card(line)).ToArray();
        var cardMatchCounts = cards
            .ToDictionary(
                x => x.Id,
                x => x.ActualNumbers.Intersect(x.WinningNumbers).Count()
            );

        var cardCounts = new int[cards.Length];
        Array.Fill(cardCounts, 1);

        for (int i = 0; i < cards.Length; i++)
        {
            int matchCount = cardMatchCounts[cards[i].Id];
            for (int j = 1; j <= matchCount && i + j < cards.Length; j++)
            {
                cardCounts[i + j] += cardCounts[i];
            }
        }

        return cardCounts.Sum();
    }
}