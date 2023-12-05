// See https://aka.ms/new-console-template for more information

internal class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        Console.WriteLine($"Part 1: {Solver.SolvePart1(lines)}");
        Console.WriteLine($"Part 2: {Solver.SolvePart2(lines)}");
    }
}

public static class Solver
{
    public static long SolvePart1(string[] lines)
    {
        // Partition lines in to lists of strings by creating a new list whenever an empty line is found.
        var partitionedLines = PartitionLines(lines)
            .Select(x => x.ToList())
            .ToList();
        
        var seeds = partitionedLines[0][0]
            .Split(": ")[1]
            .Split(" ")
            .Select(long.Parse);

        var mapGroups = new List<List<(long, long, long)>>();
        for (var i = 1; i < lines.Count(l => l == string.Empty) + 1; i++)
        {
            mapGroups.Add(partitionedLines[i][1..]
                .Select(x => x.Split(" ")
                    .Select(long.Parse)
                    .ToList()
                ).Select(x => (x[0], x[1], x[2])).ToList());
        }

        return seeds.Min(x => FindLocation(x, mapGroups));
    }

    private static long FindMapping(long input, IEnumerable<(long, long, long)> mapGroup)
    {
            var map = mapGroup.FirstOrDefault(x =>
            {
                var (dest, source, range) = x;
                return input >= source && input < source + range;
            });

            return map != default ? input + (map.Item1 - map.Item2) : input;
    }

    private static long FindLocation(long seed, List<List<(long, long, long)>> mapGroups)
    {
        var lowest = seed;
        while(mapGroups.Count > 0)
        {
            lowest = FindMapping(lowest, mapGroups.First());
            return FindLocation(lowest, mapGroups[1..]);
        }

        return lowest;
    }

    private static IEnumerable<IEnumerable<string>> PartitionLines(string[] lines)
    {
        List<List<string>> partitionedLines = new() { new List<string>() };
        foreach (var line in lines)
        {
            if (line == string.Empty)
            {
                partitionedLines.Add(new List<string>());
            }
            else
            {
                partitionedLines.Last().Add(line);
            }
        }

        return partitionedLines;
    }

    public static int SolvePart2(string[] lines)
    {
        return 0;
    }
}