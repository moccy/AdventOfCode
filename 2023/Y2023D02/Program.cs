namespace Y2023D02;

public class Program
{
    public static void Main()
    {
        var lines = File.ReadAllLines("input.txt");
        Console.WriteLine($"Part 1: {Solver.SolvePart1(lines)}");
        Console.WriteLine($"Part 2: {Solver.SolvePart2(lines)}");
    }
}
