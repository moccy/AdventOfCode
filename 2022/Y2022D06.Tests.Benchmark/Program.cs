using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Y2022D06.Tests.Benchmark;

public class Benchmark
{
    private readonly string _dataStream;

    public Benchmark()
    {
        _dataStream = File.ReadAllText("input.txt");
    }

    [Benchmark]
    public void Part1() => Y2022D06.Program.GetStartOfPacketMarker(_dataStream);

    [Benchmark]
    public void Part2() => Y2022D06.Program.GetStartOfMessageMarker(_dataStream);
}

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}