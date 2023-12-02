namespace Day02;

public class Program
{
    public static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        var games = lines.Select(line => new Game(line));
        Console.WriteLine($"Part 1: {Solver.SolvePart1(games)}");
        Console.WriteLine($"Part 2: {Solver.SolvePart2(games)}");
    }
}
