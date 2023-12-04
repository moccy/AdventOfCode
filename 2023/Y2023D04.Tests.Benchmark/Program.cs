using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Y2023D04.Tests.Benchmark;

public class Benchmark
{
    private string[] _lines;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        _lines = File.ReadAllLines("input.txt");
    }
    
    [Benchmark]
    public void SolvePart1() => Solver.SolvePart1(_lines);
    
    [Benchmark]
    public void SolvePart2() => Solver.SolvePart2(_lines);
}

internal class Program
{   
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}