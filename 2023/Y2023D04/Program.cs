namespace Y2023D04;

internal class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        Console.WriteLine($"Part 1: {Solver.SolvePart1(lines)}");
        Console.WriteLine($"Part 2: {Solver.SolvePart2(lines)}");
    }
}
