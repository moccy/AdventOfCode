namespace Y2023D04;

internal class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var solver = new Solver(lines);
        Console.WriteLine($"Part 1: {solver.SolvePart1()}");
        Console.WriteLine($"Part 2: {solver.SolvePart2()}");
    }
}
