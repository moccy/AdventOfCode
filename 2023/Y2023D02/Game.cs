namespace Y2023D02;

public class Game
{
    public int Id { get; set; }
    public List<Dictionary<CubeColour, int>> Observations { get; set; }

    public Game(string gameString)
    {
        var splitGameString = gameString.Split(": ");
        Id = int.Parse(splitGameString[0].Split(' ')[1]);
        Observations = ParseObservationsString(splitGameString[1]).ToList();
    }

    public Dictionary<CubeColour, int> MaximumSeen()
    {
        return Observations
            .SelectMany(x => x)
            .GroupBy(x => x.Key)
            .ToDictionary(
                group => group.Key,
                group => group.Max(x => x.Value)
            );
    }

    private IEnumerable<Dictionary<CubeColour, int>> ParseObservationsString(string rawObservations)
    {
        return rawObservations
            .Split("; ")
            .Select(obs => obs
                .Split(", ")
                .Select(x => new KeyValuePair<CubeColour, int>(
                    x.Split(' ')[1] switch
                    {
                        "red" => CubeColour.Red,
                        "green" => CubeColour.Green,
                        "blue" => CubeColour.Blue,
                        _ => throw new ArgumentException($"Invalid colour found in string {x} from observation string {obs}")
                    },
                    int.Parse(x.Split(' ')[0])
                )).ToDictionary(x => x.Key, x => x.Value));
    }
}
