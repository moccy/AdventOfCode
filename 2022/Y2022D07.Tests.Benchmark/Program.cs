using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Y2022D07.Tests.Benchmark;

public class Benchmark
{
    private readonly IEnumerable<string> _lines;

    public Benchmark()
    {
        _lines = File.ReadAllLines("input.txt");
    }

    [Benchmark]
    public void Part1() => Y2022D07.Program.Part1(_lines);

    [Benchmark]
    public void Part2() => Y2022D07.Program.Part2(_lines);
}

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}