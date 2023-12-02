namespace Day02;

public class Solver
{
    public static int SolvePart1(IEnumerable<Game> games)
    {
        Dictionary<CubeColour, int> MaxSizes = new() {
            { CubeColour.Red, 12 },
            { CubeColour.Green, 13 },
            { CubeColour.Blue, 14 },
        };

        int sum = 0;

        foreach (var game in games)
        {
            bool valid = true;
            foreach (var maxObservation in game.MaximumSeen())
            {
                if (MaxSizes[maxObservation.Key] < maxObservation.Value)
                {
                    valid = false;
                }
            }

            if (!valid) continue;
            sum += game.Id;
        }

        return sum;
    }

    public static int SolvePart2(IEnumerable<Game> games)
    {
        var sum = 0;
        foreach (var game in games)
        {
            var power = 1;
            foreach (var maxValues in game.MaximumSeen().Select(x => x.Value))
            {
                power *= maxValues;
            }
            sum += power;
        }
        return sum;
    }
}

